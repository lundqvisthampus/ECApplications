using ECConsoleApp.Services;

ContactService contactService = new ContactService();

MenuService menuService = new MenuService(contactService);
menuService.ShowMenu();