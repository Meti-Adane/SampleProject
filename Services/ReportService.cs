
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using sitesampleproject.Data;
using sitesampleproject.Models;

namespace sitesampleproject.Services;

public class ReportService {
    private readonly AppDBContext _context;

    public ReportService (AppDBContext context){
        _context = context;
    }


    // Record Services 
    public IEnumerable<SaleRecord> GetAllReports(Guid userid, DateTime startDate, DateTime endDate){
        var user = _context.Users.Find(userid);
        if (user is null) {
            throw new NullReferenceException("User doesnt exist");
        }
        var role = _context.Roles.SingleOrDefault(p => p.Id == user.RoleId);
        IEnumerable<SaleRecord> reports = _context.SaleRecords.Where(record => (record.CreatedAt >= startDate) && (record.CreatedAt <= endDate));
        
        if (role is null || role.RoleName == "Customer"){
            throw new AccessViolationException("Access Denied");
        } else if (role.RoleName == "Branch_Manager"){
            return reports.Where(record => record.Branch.Id == role.Accesses);
        } else if (role.RoleName == "Sales_Person"){
            return reports.Where(record => record.Author.Id == userid).ToList();
        } else if (role.RoleName == "Unit_Manager"){
            return reports.Where(record => record.Unit.Id == role.Accesses).ToList();
        }
        return reports.OrderBy(record => record.CreatedAt).ToList();
            
    }
    
}