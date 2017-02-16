using Core.Crosscutting.Commands;
using Core.Crosscutting.Validators;
using Sofia.Domain.Avaliacoes.Entities;
using Sofia.Domain.Avaliacoes.Repositories;
using Sofia.SharedKernel.ValueObjects;

namespace Sofia.Domain.Avaliacoes.Commands
{
    public class AvaliacaoCommandHandler :
        Notifiable,
        ICommandHandler<AtualizarNivelCommand>
    {
        readonly IAvaliacaoRepository _avaliacaoRepository;

        public AvaliacaoCommandHandler(IAvaliacaoRepository avaliacaoRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
        }

        public void Handle(AtualizarNivelCommand command)
        {
            var avaliacao = _avaliacaoRepository.Obter(command.IdColaborador, command.IdTecnologia);
            if (avaliacao == null)
            {
                var colaborador = _avaliacaoRepository.ObterColaborador(command.IdColaborador);
                var tecnologia = _avaliacaoRepository.ObterTecnologia(command.IdTecnologia);

                avaliacao = new Avaliacao(colaborador, tecnologia, command.Conceito);

                _avaliacaoRepository.Add(avaliacao);

                AddNotifications(avaliacao.Notifications);
            }
            else
            {
                if (command.Conceito == Nivel.NaoConheco)
                {
                    _avaliacaoRepository.Remove(avaliacao);
                }
                else
                {
                    avaliacao.MudarAvaliacao(command.Conceito);

                    _avaliacaoRepository.Update(avaliacao);
                }

                AddNotifications(avaliacao.Notifications);
            }
        }
    }
}
