namespace Lab1.Models
{
    public class Car
    {
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public string? Image { get; set; }
        public string? HtmlDescription { get; set; }
        public DateTime FirstUseDate { get; set; }

        public static List<Car> GetCars()
            => new() {
                new Car
                {
                    Manufacturer = "Toyota",
                    Model = "Camry",
                    Image = "camry.jpg",
                    HtmlDescription = "<p>The Toyota Camry is a mid-size car manufactured by Toyota since 1982.</p>",
                    FirstUseDate = new DateTime(1982, 3, 4)
                },
                new Car
                {
                    Manufacturer = "Honda",
                    Model = "Civic",
                    Image = "civic.jpg",
                    HtmlDescription = "<p>The Honda Civic is a line of cars manufactured by Honda.</p>",
                    FirstUseDate = new DateTime(1972, 7, 11)
                },
                new Car {
                    Manufacturer = "Ford",
                    Model = "Mustang",
                    Image = "mustang.jpg",
                    HtmlDescription = "<p>The Ford Mustang is a series of American muscle cars.</p>",
                    FirstUseDate = new DateTime(1964, 4, 17)
                },
                new Car {
                    Manufacturer = "Chevrolet",
                    Model = "Corvette",
                    Image = "corvette.jpg",
                    HtmlDescription = "<p>The Chevrolet Corvette is a sports car produced by Chevrolet.</p>",
                    FirstUseDate = new DateTime(1953, 6, 30)
                },
                new Car {
                    Manufacturer = "Mercedes-Benz",
                    Model = "S-Class",
                    Image = "sclass.jpg",
                    HtmlDescription = "<p>The Mercedes-Benz S-Class is a series of luxury cars.</p>",
                    FirstUseDate = new DateTime(1972, 6, 1)
                },
                new Car {
                    Manufacturer = "BMW",
                    Model = "3 Series",
                    Image = "3series.jpg",
                    HtmlDescription = "<p>The BMW 3 Series is a line of compact executive cars.</p>",
                    FirstUseDate = new DateTime(1975, 5, 2)
                },
                new Car {
                    Manufacturer = "Audi",
                    Model = "A4",
                    Image = "a4.jpg",
                    HtmlDescription = "<p>The Audi A4 is a line of compact executive cars.</p>",
                    FirstUseDate = new DateTime(1994, 11, 4)
                },
                new Car {
                    Manufacturer = "Mazda",
                    Model = "MX-5",
                    Image = "mx5.jpg",
                    HtmlDescription = "<p>The Mazda MX-5 is a two-seater sports car manufactured by Mazda.</p>",
                    FirstUseDate = new DateTime(1989, 5, 18)
                },
                new Car {
                    Manufacturer = "Porsche",
                    Model = "911",
                    Image = "911.jpg",
                    HtmlDescription = "<p>The Porsche 911 is a line of high-performance sports cars.</p>",
                    FirstUseDate = new DateTime(1963, 9, 12)
                },
                new Car {
                    Manufacturer = "Tesla",
                    Model = "Model S",
                    Image = "models.jpg",
                    HtmlDescription = "<p>The Tesla Model S is an electric car produced by Tesla, Inc.</p>",
                    FirstUseDate = new DateTime(2012, 6, 22)
                }
            };

    }
}
