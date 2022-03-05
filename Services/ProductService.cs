
using sitesampleproject.Data;
using sitesampleproject.Models;
namespace sitesampleproject.Services;
public class ProductService{
    private readonly AppDBContext _context;

    public ProductService (AppDBContext context){
        _context = context;
    }

    public IEnumerable<Product> GetAll(){
        return _context.Products.ToList();
    }
    public Product? GetById(Guid id){
        return _context.Products
        .SingleOrDefault(p => p.Id == id);
    }
    public double GetUnitPrice(){
        return _context.Products.SingleOrDefault().Price;
    }

}