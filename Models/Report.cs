using System.ComponentModel.DataAnnotations;

namespace sitesampleproject.Models;

public class Report{
    public Guid Id {get; set;}
    [Required]
    public User CreatedBy {get; set;}
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt {get; set;}
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime DateIntervalStart {get; set;}
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime DateIntervalEnd {get; set;}

}