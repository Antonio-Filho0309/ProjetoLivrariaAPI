﻿namespace ProjetoLivrariaAPI.Models {
    public class Users {

        public Users() { }

        public Users(int id, string name, string city, string email, string address) {

            this.Id = id;
            this.Name = name;
            this.City = city;
            this.Email = email;
            this.Address = address;


        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
    }
}
