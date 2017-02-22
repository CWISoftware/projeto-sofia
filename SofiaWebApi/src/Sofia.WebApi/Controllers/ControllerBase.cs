using Core.Crosscutting.Transactions;
using Core.Crosscutting.Validators;
using Microsoft.AspNetCore.Mvc;
using Sofia.SharedKernel.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sofia.WebApi.Controllers
{
    public class ControllerBase : Controller
    {
        readonly IUnitOfWork[] _uow;
        static readonly IEnumerable<Notification> _emptyNotification = new Notification[] { };

        public ControllerBase()
        {
        }

        public ControllerBase(params IUnitOfWork[] uow)
        {
            _uow = uow;
        }

        public async new Task<IActionResult> Response()
        {
            return await ResponseInternal(null, _emptyNotification);
        }

        public async new Task<IActionResult> Response(object result)
        {
            return await ResponseInternal(result, _emptyNotification);
        }

        public async new Task<IActionResult> Response(IEnumerable<Notification> notifications)
        {
            return await ResponseInternal(null, notifications);
        }

        public async new Task<IActionResult> Response(object result, IEnumerable<Notification> notifications)
        {
            return await ResponseInternal(result, notifications);
        }

        private Task<IActionResult> ResponseInternal(object result, IEnumerable<Notification> notifications)
        {
            var tsc = new TaskCompletionSource<IActionResult>();

            if (!notifications.Any())
            {
                try
                {
                    if (_uow != null)
                        foreach (var uow in _uow)
                            uow.Commit();

                    tsc.SetResult(Ok(new
                    {
                        success = true,
                        data = result
                    }));
                }
                catch
                {
                    // Logar o erro (Elmah)

                    tsc.SetResult(
                        BadRequest(new
                        {
                            success = false,
                            errors = new[] { Messages.InternalServerError }
                        }));
                }
            }
            else
            {
                tsc.SetResult(
                    BadRequest(new
                    {
                        success = false,
                        errors = notifications
                    }));
            }

            return tsc.Task;
        }
    }
}
