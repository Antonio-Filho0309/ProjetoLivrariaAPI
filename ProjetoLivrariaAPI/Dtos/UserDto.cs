namespace ProjetoLivrariaAPI.Dtos {

    public class UserDto {

        public string Id { get; set; }

        public string Name { get; set; }
        public string City { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }


    }
    public class CreateUserDto {

        public string Name { get; set; }
        public string City { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }


    }

    

   
}
