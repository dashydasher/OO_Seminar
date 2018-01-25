using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Plivanje.Models;
using Plivanje.Repositories;
using Plivanje.Processors;
using System.Collections.Generic;

namespace Unit_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void Hall_Test()
        {
            string name = "Bazeni Šalata";
            string addres = "Šalatska 105";
            var place = new Place();

            var hall = new Hall(name, addres, place);

            Assert.AreEqual(name, hall.Name, "Wrong name");
            Assert.AreEqual(addres, hall.Address, "Wrong address");
            Assert.AreEqual(place, hall.Place, "Wrong place");
        }

        //Mocking testovi
        [TestMethod]
        public void Validate_Login()
        {
            string email = "nikola.marinkovic@gmail.com";
            string password = "nikola";
            int userId = 3;
            Coach coach= new Coach { Id = 2, Password = "nikola", EMail = "nikola.marinkovic@gmail.com" };
            Coach person = new Coach();

            var repository = new Mock<IUserRepository>();
            repository.Setup(x => x.GetUserByUsernameAndPassword(email, password, 1)).Returns(coach);
            repository.Setup(x => x.GetRegisteredPersonFromUserId(userId)).Returns(person);

            DataProcessor processor = new DataProcessor();
            processor.Repository = (IUserRepository)repository.Object;

            var res = processor.ProccesData(email, password, 1);

            repository.Verify(x => x.GetUserByUsernameAndPassword(email, password, 1), Times.Exactly(1));
        }

        [TestMethod]
        public void Validate_SaveUpdatePerson()
        {
            string firstName = "Bal";
            string lastName = "Bal";
            string date = "05.05.1955.";
            string email = "blabla@dfs";
            string pass = "blabla";
            int id = 7;

            RegisteredPerson user = new Coach();
            var coach = new Coach();

            var repository = new Mock<IUserRepository>();
            repository.Setup(x => x.GetRegisteredPersonFromUserId(id)).Returns(coach);
            repository.Setup(x => x.SaveUpdateRegisteredPerson(coach));

            DataProcessor processor = new DataProcessor();
            processor.Repository = (IUserRepository)repository.Object;

            var res = processor.SaveUpdatePerson(id, firstName, lastName, date, email, pass, user);

            repository.Verify(x => x.GetRegisteredPersonFromUserId(id), Times.Exactly(1));
            repository.Verify(x => x.SaveUpdateRegisteredPerson(coach), Times.Exactly(1));
        }

        [TestMethod]
        public void Validate_GetClub()
        {
            int id = 1;
            var club = new Club();

            var repository = new Mock<IClubRepository>();
            repository.Setup(x => x.getClub(1)).Returns(club);

            ClubProcessor processor = new ClubProcessor();
            processor.Repository = (IClubRepository)repository.Object;

            var res = processor.getClub(id);

            repository.Verify(x => x.getClub(id), Times.Exactly(1));
        }

        [TestMethod]
        public void Validate_GetClubs()
        {
            var clubs = new List<Club>();

            var repository = new Mock<IClubRepository>();
            repository.Setup(x => x.getClubs()).Returns(clubs);

            ClubProcessor processor = new ClubProcessor();
            processor.Repository = (IClubRepository)repository.Object;

            var res = processor.getClubs();

            repository.Verify(x => x.getClubs(), Times.Exactly(1));
        }

        [TestMethod]
        public void Validate_ListOfHalls()
        {
            var halls = new List<Hall>();

            var repository = new Mock<IHallRepository>();
            repository.Setup(x => x.getHalls()).Returns(halls);

            HallProcessor processor = new HallProcessor();
            processor.Repository = (IHallRepository)repository.Object;

            var res = processor.ListOfhall();

            repository.Verify(x => x.getHalls(), Times.Exactly(1));
        }

        [TestMethod]
        public void Validate_ChangeNameCompetition()
        {
            string competitionName = "Veliki dupin";
            int id = 2;
            Competition comp = new Competition();

            var repository = new Mock<ICompetitionRepository>();
            repository.Setup(x => x.getCompetition(id)).Returns(comp);
            repository.Setup(x => x.UpdateCompetition(comp));

            CompetitionProcessor processor = new CompetitionProcessor();
            processor.Repository = (ICompetitionRepository)repository.Object;

            var res = processor.ChangeNameCompetition(id, competitionName);

            repository.Verify(x => x.getCompetition(id), Times.Exactly(1));
            repository.Verify(x => x.UpdateCompetition(comp), Times.Exactly(1));
        }

        [TestMethod]
        public void Validate_RetrieveRaceDetail()
        {
            int id = 4;
            Race race = new Race();
            List<SwimmerRace> listOfSwimmers = new List<SwimmerRace>();
   

            var repository = new Mock<IRaceRepository>();
            repository.Setup(x => x.getRace(id)).Returns(race);
            repository.Setup(x => x.SwimmersOnRace(id)).Returns(listOfSwimmers);
     

            RaceProcessor processor = new RaceProcessor();
            processor.Repository = (IRaceRepository)repository.Object;

            var res = processor.getRace(id);

            repository.Verify(x => x.getRace(id), Times.Exactly(1));
    
        }

        [TestMethod]
        public void Validate_SetRaceReferee()
        {
            int id = 4;
            int refereeId = 1;
            Race race = new Race();
            Referee referee = new Referee();

            var RaceRepository = new Mock<IRaceRepository>();
            var userRepository = new Mock<IUserRepository>();
            RaceRepository.Setup(x => x.getRace(id)).Returns(race);
            RaceRepository.Setup(x => x.UpdateRace(race));
            userRepository.Setup(x => x.GetRegisteredPersonFromUserId(refereeId)).Returns(referee);

            RaceProcessor processor = new RaceProcessor();
            processor.Repository = (IRaceRepository)RaceRepository.Object;
            processor.userRepository = (IUserRepository)userRepository.Object;

            processor.SetRaceReferee(refereeId,id);

            RaceRepository.Verify(x => x.getRace(id), Times.Exactly(1));
            userRepository.Verify(x => x.GetRegisteredPersonFromUserId(refereeId), Times.Exactly(1));
        }

   
        [TestMethod]
        public void Validate_RetrieveSwimmerLicence()
        {
            int id = 3;
            bool result = false; ;

            var repository = new Mock<ISwimmerRepository>();
            repository.Setup(x => x.getSwimmerLicence(id)).Returns(result);

            SwimmerProcessor processor = new SwimmerProcessor();
            processor.Repository = (ISwimmerRepository)repository.Object;

            var res = processor.getSwimmerLicence(id);
            repository.Verify(x => x.getSwimmerLicence(id), Times.Exactly(1));
        }





    }
}
