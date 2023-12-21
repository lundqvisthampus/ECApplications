﻿using ECGraphicApp.Models;

namespace ECGraphicApp.Interfaces;

internal interface IContactService
{
    public void AddContact(Contact contact);

    public List<Contact> GetContactList();

    public void RemoveContact(Contact contact);
    Contact ShowContactInfo(Contact contact);
}