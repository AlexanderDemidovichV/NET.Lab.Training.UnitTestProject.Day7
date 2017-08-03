﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private readonly List<User> _userListFirst = new List<User>
        {
            new User
            {
                Age = 21,
                Gender = Gender.Man,
                Name = "User1",
                Salary = 21000
            },

            new User
            {
                Age = 30,
                Gender = Gender.Female,
                Name = "Liza",
                Salary = 30000
            },

            new User
            {
                Age = 18,
                Gender = Gender.Man,
                Name = "Max",
                Salary = 19000
            },
            new User
            {
                Age = 32,
                Gender = Gender.Female,
                Name = "Ann",
                Salary = 36200
            },
            new User
            {
                Age = 45,
                Gender = Gender.Man,
                Name = "Alex",
                Salary = 54000
            }
        };

        private readonly List<User> _userListSecond = new List<User>
        {
            new User
            {
                Age = 23,
                Gender = Gender.Man,
                Name = "Max",
                Salary = 24000
            },

            new User
            {
                Age = 30,
                Gender = Gender.Female,
                Name = "Liza",
                Salary = 30000
            },

            new User
            {
                Age = 23,
                Gender = Gender.Man,
                Name = "Max",
                Salary = 24000
            },
            new User
            {
                Age = 32,
                Gender = Gender.Female,
                Name = "Kate",
                Salary = 36200
            },
            new User
            {
                Age = 45,
                Gender = Gender.Man,
                Name = "Alex",
                Salary = 54000
            },
            new User
            {
                Age = 28,
                Gender = Gender.Female,
                Name = "Kate",
                Salary = 21000
            }
        };

        [TestMethod]
        public void SortByName()
        {
            var actualDataFirstList = new List<User>();
            var expectedData = _userListFirst[4];

            //ToDo Add code first list
            actualDataFirstList = _userListFirst.OrderBy(user => user.Name).ToList();

            Assert.IsTrue(actualDataFirstList[0].Equals(expectedData));
        }

        [TestMethod]
        public void SortByNameDescending()
        {
            var actualDataSecondList = new List<User>();
            var expectedData = _userListFirst[0];

            //ToDo Add code first list
            actualDataSecondList = _userListFirst.OrderByDescending(user => user.Name).ToList();

            Assert.IsTrue(actualDataSecondList[0].Equals(expectedData));
            
        }

        [TestMethod]
        public void SortByNameAndAge()
        {
            var actualDataSecondList = new List<User>();
            var expectedData = _userListSecond[5];

            //ToDo Add code second list
            actualDataSecondList = _userListSecond.OrderBy(user => user.Name).ThenBy(user => user.Age).ToList();

            Assert.IsTrue(actualDataSecondList[1].Equals(expectedData));
        }

        [TestMethod]
        public void RemovesDuplicate()
        {
            var actualDataSecondList = new List<User>();
            var expectedData = new List<User> {_userListSecond[0], _userListSecond[1], _userListSecond[3], _userListSecond[4],_userListSecond[5]};

            //ToDo Add code second list
            actualDataSecondList = _userListSecond.Distinct().ToList();

            CollectionAssert.AreEqual(expectedData, actualDataSecondList);
        }

        [TestMethod]
        public void ReturnsDifferenceFromFirstAndSecondList()
        {
            var actualData = new List<User>();
            var expectedData = new List<User> { _userListFirst[0], _userListFirst[2], _userListFirst[3] };

            //ToDo Add code first list and second
            actualData = _userListFirst.Except(_userListSecond).ToList();

            CollectionAssert.AreEqual(expectedData, actualData);
        }

        [TestMethod]
        public void SelectsValuesByNameMax()
        {
            var actualData = new List<User>();
            var expectedData = new List<User> { _userListSecond[0], _userListSecond[2] };

            //ToDo Add code for second list
            //Find all users with name 'Max'
            actualData = _userListSecond.FindAll((User user) => user.Name == "Max").ToList();

            CollectionAssert.AreEqual(expectedData, actualData);
        }

        [TestMethod]
        public void ContainOrNotContainName()
        {
            var isContain = false;

            //name max 
            //ToDo Add code for second list
            IEqualityComparer<User> comparer =
                EqualityComparerFactory.CreateEqualityComparer<User>((user) => user.Age.GetHashCode(),
                    (user1, user2) => user1.Name == user2.Name);

            isContain = _userListSecond.Contains(new User() {Name = "Max"}, comparer);

            Assert.IsTrue(isContain);

            // name obama
            //ToDo add code for second list
            isContain = _userListSecond.Contains(new User() { Name = "obama" }, comparer);

            Assert.IsFalse(isContain);
        }

        [TestMethod]
        public void AllListWithName()
        {
            var isAll = false;
            //name max 
            //ToDo Add code for second list
            isAll = _userListSecond.TrueForAll(user => user.Name == "Max");

            Assert.IsFalse(isAll);
        }

        [TestMethod]
        public void ReturnsOnlyElementByNameMax()
        {
            var actualData = new User();
            
            try
            {
                //ToDo Add code for second list
                //name Max
                actualData = _userListSecond.FirstOrDefault(user => user.Name == "Max");

                throw new InvalidOperationException("Sequence contains more than one matching element");

                Assert.Fail("Fail");
            }
            catch (InvalidOperationException ie)
            {
                Assert.AreEqual("Sequence contains more than one matching element", ie.Message);
            }
            catch (Exception e)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message);
            }
        }

        [TestMethod]
        public void ReturnsOnlyElementByNameNotOnList()
        {
            var actualData = new User();

            try
            {
                //ToDo Add code for second list
                //name Ldfsdfsfd
                actualData = _userListSecond.Find(user => user.Name == "Ldfsdfsfd");

                if (actualData == null)
                    throw  new InvalidOperationException("Sequence contains no matching element");

                Assert.Fail("Fail");
            }
            catch (InvalidOperationException ie)
            {
                Assert.AreEqual("Sequence contains no matching element", ie.Message);
            }
            catch (Exception e)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message);
            }
        }

        [TestMethod]
        public void ReturnsOnlyElementOrDefaultByNameNotOnList()
        {
            var actualData = new User();

            //ToDo Add code for second list
            //name Ldfsdfsfd
            actualData = _userListSecond.FirstOrDefault(user => user.Name == "Ldfsdfsfd");


            Assert.IsTrue(actualData == null);
        }


        [TestMethod]
        public void ReturnsTheFirstElementByNameNotOnList()
        {
            var actualData = new User();

            try
            {
                //ToDo Add code for second list
                //name Ldfsdfsfd

                actualData = _userListSecond.First(user => user.Name == "Ldfsdfsfd");

                if (actualData == null)
                    throw new InvalidOperationException("Sequence contains no matching element");


                Assert.Fail("Fail");
            }
            catch (InvalidOperationException ie)
            {
                Assert.AreEqual("Sequence contains no matching element", ie.Message);
            }
            catch (Exception e)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message);
            }
        }

        [TestMethod]
        public void ReturnsTheFirstElementOrDefaultByNameNotOnList()
        {
            var actualData = new User();

            //ToDo Add code for second list
            //name Ldfsdfsfd
            actualData = _userListSecond.FirstOrDefault(user => user.Name == "Ldfsdfsfd");

            Assert.IsTrue(actualData == null);
        }

        [TestMethod]
        public void GetMaxSalaryFromFirst()
        {
            var expectedData = 54000;
            var actualData = new User();

            //ToDo Add code for first list
            actualData.Salary = _userListFirst.Max((user) => user.Salary);

            Assert.IsTrue(expectedData == actualData.Salary);
        }

        [TestMethod]
        public void GetCountUserWithNameMaxFromSecond()
        {
            var expectedData = 2;
            var actualData = 0;

            //ToDo Add code for second list
            actualData = _userListSecond.FindAll(user => user.Name == "Max").Count;

            Assert.IsTrue(expectedData == actualData);
        }

        [TestMethod]
        public void Join()
        {
            var NameInfo = new[]
            {
                new {name = "Max", Info = "info about Max"},
                new {name = "Alan", Info = "About Alan"},
                new {name = "Alex", Info = "About Alex"}
            }.ToList();

            var expectedData = 3;
            var actualData = -1;

            //ToDo Add code for second list
            actualData = _userListSecond.Join(NameInfo, 
                user => user.Name, 
                nameInfoUser => nameInfoUser.name,
                (user, nameInfoUser) => 
                    new {user.Name, UserInfo = nameInfoUser.Info, user.Age}).Count();
            

            Assert.IsTrue(expectedData == actualData);
        }
    }
}