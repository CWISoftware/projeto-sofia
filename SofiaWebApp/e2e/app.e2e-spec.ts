import { SofiaWebAppPage } from './app.po';

describe('sofia-web-app App', () => {
  let page: SofiaWebAppPage;

  beforeEach(() => {
    page = new SofiaWebAppPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
