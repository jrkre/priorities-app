using priorities.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace priorities.Models
{
    public class TaskItem
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Size { get; set; }
        [Required]
        public bool Complete { get; set; }


        /*public TaskItem(string name, string description, DateTime duedate, int size)
        {
            Name = name;
            Description= description;
            DueDate = duedate;
            Size = size;
            Created = DateTime.Now;
            Complete = false;
        }

        public TaskItem(TaskViewModel model)
        {
            DueDate = model.DueDate;
            Size = model.Size;
            Name = model.Name;
            Description = model.Description;
            Created = DateTime.Now;
            Complete = false;
        }*/

    }
}
