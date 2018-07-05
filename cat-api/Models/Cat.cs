using System;
using System.ComponentModel.DataAnnotations;

namespace cat_api
{
    public class Cat
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public int Age { get; set; }
        public Breeds Breed { get; set; }
    }
    public enum Breeds
    {
        MaineCoon,
        Bengal,
        NorwegianForestCat,
        Persian,
        Siamese,
        TuxedoCat
    }
}