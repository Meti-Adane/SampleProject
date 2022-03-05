
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using sitesampleproject.Data;
using sitesampleproject.Models;

namespace sitesampleproject.Services;

public class SalesService {
    private readonly AppDBContext _context;

    public SalesService (AppDBContext context){
        _context = context;
    }


    // Record Services 
    public IEnumerable<SaleRecord> GetAllRecords(Guid authorId){
        var user = _context.Users.Find(authorId);
        if (user is null) {
            throw new NullReferenceException("User doesnt exist");
        }

        var role = _context.Roles.SingleOrDefault(p => p.Id == user.RoleId);

        if (role is null || role.RoleName == "Customer"){
            throw new AccessViolationException("Access Denied");
        } else if (role.RoleName == "Branch_Manager"){
            return _context.SaleRecords.Where(record => record.Branch.Id == role.Accesses);
        } else if (role.RoleName == "Sales_Person"){
            return _context.SaleRecords.Where(record => record.Author.Id == authorId).ToList();
        } else if (role.RoleName == "Unit_Manager"){
            return _context.SaleRecords.Where(record => record.Unit.Id == role.Accesses).ToList();
        }
        return _context.SaleRecords.OrderBy(record => record.CreatedAt).ToList();
            
    }
    public SaleRecord? GetRecordById(Guid userId, Guid recordId){

        User? user = _context.Users.Find(userId);
        SaleRecord? record = _context.SaleRecords.SingleOrDefault(record => record.Id == recordId);
        Role? role = _context.Roles.SingleOrDefault(role => role.Id == user.RoleId);

        if (user is null || record is null || role is null || role.RoleName == "Customer"){
            throw new NullReferenceException("Record not found");
        }
        else if (user.Id == record.Author.Id || role.Accesses == record.Branch.Id || role.Accesses == record.Unit.Id) {
            return record;
        }
        throw new AccessViolationException("Access Denied");
    }
    public SalesPerson? GetSalesPersonById(Guid userid){

        SalesPerson? user = _context.SalesPerson.Find(userid);
       
        if (user is null){
            throw new NullReferenceException("User not found");
        }
        return user;
       
    }
    public SaleRecord CreateRecord(SaleRecord newSaleRecord)
    {
        _context.SaleRecords.Add(newSaleRecord);
        _context.SaveChangesAsync();

        return newSaleRecord;
    }
    public bool DeleteRecord(Guid recordId){
        SaleRecord? record = _context.SaleRecords.SingleOrDefault(record => record.Id == recordId);
        if (record is null) {
            throw new NullReferenceException("Record not found");
        }else{
            _context.SaleRecords.Remove(record);
            _context.SaveChanges();
            return true;
        }
    }
    
    
    // Plan services 
    public void UpdateRecord(Guid recordID, SaleRecord newrecord){
        var recordToUpdate = _context.SaleRecords.Find(recordID);
        if (recordToUpdate is null){
            throw new NullReferenceException("Record not found");
        } 
        recordToUpdate = newrecord;
        _context.SaleRecords.Update(recordToUpdate);
        _context.SaveChangesAsync();
        
    }
    public IEnumerable<Plan> GetAllPlans(Guid userId){
        var user = _context.Users.Find(userId);
        if (user is null) {
            throw new NullReferenceException("User doesnt exist");
        }
        return _context.Plans.Where(plan => plan.Author.Id == userId);
            
    }
    public Plan? GetPlanById(Guid userId, Guid planId){

        User? user = _context.Users.Find(userId);
        Plan? plan = _context.Plans.SingleOrDefault(plan => plan.Id == planId);

        if (user is null || plan is null){
            throw new NullReferenceException("Plan not found");
        }
        else if (user.Id == plan.Author.Id) {
            return plan;
        }
        throw new AccessViolationException("Access Denied");
    }
    
    public Plan CreatePlan(Plan newplan){
        
        _context.Plans.Add(newplan);
        _context.SaveChangesAsync();
        return newplan;        
    }
    
    public bool DeletePlan(Guid planId){
        Plan? plan = _context.Plans.SingleOrDefault(plan => plan.Id == planId);
        if (plan is null) {
            throw new NullReferenceException("Record not found");
            return false;
        }else{
            _context.Plans.Remove(plan);
            _context.SaveChanges();
            return true;
        }
    }

    public void UpdatePlan(Guid planId, Plan newplan){
        Plan? planToUpdate = _context.Plans.SingleOrDefault(plan => plan.Id == planId);
        if (planToUpdate is null) {
            throw new NullReferenceException("Record not found");
        }else{
            planToUpdate = newplan;
            _context.Plans.Update(planToUpdate);
            _context.SaveChanges();
        } 
    }
}