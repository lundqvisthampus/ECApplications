using ECConsoleApp.Services;

ContactService contactService = new ContactService();
MenuService menuService = new MenuService(contactService);

contactService.GetContactList();
menuService.ShowMenu();