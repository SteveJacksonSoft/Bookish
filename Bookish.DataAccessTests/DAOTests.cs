using System;
using NUnit.Framework;
using Bookish.DataAccess;
using Bookish.DataAccess.Models;

namespace Bookish.DataAccessTests {
    public class Tests {
        private DatabaseAccessObject _dao;
        
        [SetUp]
        public void Setup() {
            _dao = new DatabaseAccessObject();
        }

        [Test]
        public void ShouldBeAbleToAddBookWithoutErrors() {
            int idOfBook = -1;
            try {
                BookForDB book = new BookForDB(
                    "59872",
                    "TestBook",
                    "Meeeee"
                );

                idOfBook = _dao.Add(book);
            } catch (Exception e) {
                Assert.Fail(e.Message);
            }

            Assert.AreNotEqual(idOfBook, -1);
        }
    

        [Test]
        public void ShouldBeAbleToAddUserWithoutErrors() {
            int idOfUser = -1;
            try {
                UserForDB user = new UserForDB("Polly Parrot");

                idOfUser = _dao.Add(user);
            } catch (Exception e) {
                Assert.Fail(e.Message);
            }
            
            Assert.AreNotEqual(idOfUser, -1);
        }


        [Test]
        public void ShouldBeAbleToAddLoanWithoutErrors() {
            int idOfLoan = -1;
            try {
                LoanForDB loan = new LoanForDB(
                    0,
                    0,
                    "20190221",
                    "20200103",
                    false);

                idOfLoan = _dao.Add(loan);
            } catch (Exception e) {
                Assert.Fail(e.Message);
            }

            Assert.AreNotEqual(idOfLoan, -1);
        }
    }
}