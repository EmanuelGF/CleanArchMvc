using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    //Setting the class has sealed garanties that it can not be inherited. It's isolated.
    public sealed class Category : Entity
    {

        //Properties

        //Setting the property setter to private ensures that they can not be modified externaly.

        //The Id property is inherited from the abstract class Entity.
        public string Name { get; private set; }

        //Defines the relations to the Product model. This will help with the database creation.
        public ICollection<Product> Products { get; private set; }


        //Constructors
        public Category(string name)
        {
            //example of direct validation.
            //Name = name ?? throw new ArgumentException("Name is Invalid");

            //This method is using the DomainExceptionValidation class on the Validation Folder.
            ValidateDomainNameProp(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomainNameProp(name);
        }

        //Methods
        public void Update(string name)
        {
            ValidateDomainNameProp(name);
        }

        private void ValidateDomainNameProp(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required.");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name. Length less than 3.");
            
            Name = name;
        }


    }
}


/*
-This model is isolated from the external world ensuring that the class is sealed and cannot be inherited
-The setters are private, so they cannot be modified externally and only via constructor.
-The constructor is parameterized.
-Has property validation.
 */