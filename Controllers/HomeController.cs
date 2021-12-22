using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.Data;
using University.Models;

namespace University.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly StudentDbContext _db;


    public HomeController(ILogger<HomeController> logger, StudentDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Student()
    {
        IEnumerable<Student> objStudentList = _db.Students;
        return View(objStudentList);
    }
    public IActionResult Teacher()
    {
        IEnumerable<Teacher> objTeacherList = _db.Teachers.Include(x => x.Discipline);
        return View(objTeacherList);
    }
    //CREATE NEW STUDENT method get
    public IActionResult Create()
    {

        return View();
    }
    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Student obj)
    {


        _db.Students.Add(obj);
        _db.SaveChanges();
        return RedirectToAction("Student");
    }
    //EDIT STUDENTS METHOD 
    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var studentFormDb = _db.Students.Find(id);
        //var studentFormDbFirst=_db.Students.FirstOrDefault(x=>x.Id==id);
        // var studentFormDbSingle=_db.Students.SingleOrDefault(x=>x.Id==id);
        if (studentFormDb == null)
        {
            return NotFound();
        }
        return View(studentFormDb);
    }
    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Student obj)
    {


        _db.Students.Update(obj);
        _db.SaveChanges();
        return RedirectToAction("Student");
    }
    //DELETE STUDENTS
public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var studentFormDb = _db.Students.Find(id);
        //var studentFormDbFirst=_db.Students.FirstOrDefault(x=>x.Id==id);
        // var studentFormDbSingle=_db.Students.SingleOrDefault(x=>x.Id==id);
        if (studentFormDb == null)
        {
            return NotFound();
        }
        return View(studentFormDb);
    }
    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var obj =_db.Students.Find(id);
        if(obj==null){
            return NotFound();
        }

        _db.Students.Remove(obj);
        _db.SaveChanges();
        return RedirectToAction("Student");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
