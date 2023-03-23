using Microsoft.AspNetCore.Mvc;
using Exam_Back_End.Models;

namespace Exam_dotnet_api.Controllers;

[ApiController]
[Route("[controller]")]
public class TblFruitsController : ControllerBase
{
    private readonly ExamDbContext con_db;
     private bool _status = false;
    private string _message = "";
    private string _error = "";
    public TblFruitsController(ExamDbContext conn_db){
        this.con_db=conn_db;       
    }
   

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
      try
      {
        
        var data=this.con_db.TblFruits.ToList();
        if (data != null && data.Count > 0)
        {
          _status = true;
          _message = "";
        }else{
          _status = false;
          _message = "ไม่พบข้อมูล";
        }
        return StatusCode(200, new { status = _status, message = _message, error = _error, results = data });
      }catch(Exception ex){
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    

     [HttpPost("Insert")]
    public ActionResult Insert([FromBody] TblFruit tblFruit){      
      
      
      try{
          if(!string.IsNullOrEmpty(tblFruit.ToString())){            
            this.con_db.TblFruits.Add(tblFruit);
            this.con_db.SaveChanges();
          }
      
        _status = true;
        _message = "บันทึกข้อมูลสำเร็จ";
       return StatusCode(200, new { status = _status, message = _message, error = _error, results = tblFruit });
      }catch(Exception ex){
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }
}
