using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Puppies.Models
{
    public class PuppyViewModel
    {
        public IList<Puppy> Puppies { get; set; }
        public Puppy NewPuppy { get; set; }

    }
}
