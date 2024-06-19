using CustomIdentity.Data;
using CustomIdentity.Models;
using CustomIdentity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CustomIdentity.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly AppDbContext mContext;

    public HomeController(AppDbContext dbContext)
    {

        mContext = dbContext;
    }
    [AllowAnonymous]
    public IActionResult Index()
    {
        var contacts = mContext.Contacts.ToList();


        return View(contacts);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    //////////////////
    ///

    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Add(ContactVM contactVm)
    {
        if (ModelState.IsValid)
        {
            var user = new Contact
            {
                Name = contactVm.Name,
                LastName = contactVm.LastName,
                Email = contactVm.Email,
                Password = contactVm.Password,
                Category = contactVm.Category,
                PhoneNumber = contactVm.PhoneNumber,
                DateOfBirth = contactVm.DateOfBirth
            };

            mContext.Contacts.Add(user);
            mContext.SaveChanges();

            return RedirectToAction("Index");
        }

        return View(contactVm);
    }


   
    public IActionResult Details(int contactId)
    {
        var contact = mContext.Contacts.FirstOrDefault(x => x.Id == contactId);


        if (contact == null)
        {
            return NotFound();
        }
        
        return View(contact);
    }

     public IActionResult Delete(int contactId)
        {

        var contact = mContext.Contacts.FirstOrDefault(x => x.Id == contactId);

        mContext.Contacts.Remove(contact); 
            mContext.SaveChanges();

            return RedirectToAction("Index");
        }

    public IActionResult Edit(int contactId)
    {
        var contact = mContext.Contacts.FirstOrDefault(x => x.Id == contactId);

        if (contact == null)
        {
            return NotFound();
        }

        return View(contact); // Zwraca widok formularza edycji z danymi kontaktu
    }

    [HttpPost]
    public IActionResult Edit(Contact editedContact)
    {
        if (ModelState.IsValid)
        {
            var contactToUpdate = mContext.Contacts.FirstOrDefault(x => x.Id == editedContact.Id);

            if (contactToUpdate == null)
            {
                return NotFound();
            }

            // Aktualizuj dane kontaktu na podstawie danych z formularza
            contactToUpdate.Name = editedContact.Name;
            contactToUpdate.LastName = editedContact.LastName;
            contactToUpdate.Email = editedContact.Email;
            contactToUpdate.Password = editedContact.Password;
            contactToUpdate.Category = editedContact.Category;
            contactToUpdate.PhoneNumber = editedContact.PhoneNumber;
            contactToUpdate.DateOfBirth = editedContact.DateOfBirth;
            // Dodaj więcej pól do aktualizacji, jeśli to konieczne

            mContext.SaveChanges(); // Zapisz zmiany w bazie danych

            return RedirectToAction("Index"); // Przekieruj użytkownika na stronę główną lub inną po udanej edycji
        }

        // Jeśli ModelState nie jest poprawny, zwróć ponownie widok formularza z błędami walidacji
        return View(editedContact);
    }




}