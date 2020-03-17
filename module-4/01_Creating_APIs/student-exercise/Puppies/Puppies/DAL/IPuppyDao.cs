using Puppies.Models;
using System.Collections.Generic;

namespace Puppies.DAL
{
    public interface IPuppyDao
    {
        /// <summary>
        /// Returns a list of all puppies
        /// </summary>
        /// <returns></returns>
        IList<Puppy> GetPuppies();

        /// <summary>
        /// Returns a specific puppy
        /// </summary>
        /// <param name = "id" ></ param >
        /// <returns></returns>
        Puppy GetPuppy(int id);

        /// <summary>
        /// Saves a new puppy to the system
        /// </summary>
        /// <param name="newPuppy"></param>
        /// <returns></returns>
        int AddPuppy(Puppy newPuppy);

        /// <summary>
        /// Updates properties of an existing puppy
        /// </summary>
        /// <param name="puppy">Updated puppy information</param>
        void UpdatePuppy(Puppy puppy);

        /// <summary>
        /// Deletes an existing puppy (presumably because he got a new home...)
        /// </summary>
        /// <param name="puppyId">Id of the puppy to remove</param>
        void DeletePuppy(int puppyId);
    }
}