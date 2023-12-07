using ECConsoleApp.Services;

/// Initializing a new instance of ContactService and initializing a new instance of MenuService to
/// load the list from start, and passing the contactService as an argument to the new menuservice to 
/// make sure that the same instance of contactservice is used in the menuservice.
ContactService contactService = new ContactService();
MenuService menuService = new MenuService(contactService);

contactService.GetContactList();
menuService.ShowMenu();