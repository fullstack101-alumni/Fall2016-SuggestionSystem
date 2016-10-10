import { SuggestionSystemClientPage } from './app.po';

describe('suggestion-system-client App', function() {
  let page: SuggestionSystemClientPage;

  beforeEach(() => {
    page = new SuggestionSystemClientPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
