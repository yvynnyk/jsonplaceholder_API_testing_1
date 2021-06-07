using NUnit.Framework;
using Flurl.Http;
using System;

namespace FlurlTest1
{
    public class Tests
    {
        private string testDomain;
        private string testFolder;
        private string testId;
        private const int testStatus200 = 200; 
        private const int testStatus201 = 201;
        private Type typeData;

        [OneTimeSetUp]
        public void SetUp()
        {
            testDomain = "https://jsonplaceholder.typicode.com";
            testFolder = "/posts";
            testId = "/1";
            typeData = typeof(string);
        }
        
        [Test]
        public void GET_Test()
        {
            var testResource = testDomain + testFolder + testId;
            var response = testResource.GetAsync().Result;
            var responseBody = response.ResponseMessage.Content.ReadAsStringAsync().Result;
            var responseStatus = response.StatusCode;

            Assert.Multiple(() =>
            {
                Assert.That(responseBody.GetType(), Is.EqualTo(typeData));
                Assert.That(responseStatus, Is.EqualTo(testStatus200));
            });
        }
        [Test]
        public void POST_Test()
        {
            var testResource = testDomain + testFolder;
            var response = testResource
                .PostJsonAsync(new
                {
                    title = "Title1",
                    body = "Body1",
                    userId = 1,
                });
            var responseBody = response.Result.ResponseMessage.Content.ReadAsStringAsync().Result;
            var responseStatus = response.Result.StatusCode;

            Assert.Multiple(() =>
            {
                Assert.That(responseBody.GetType(), Is.EqualTo(typeData));
                Assert.That(responseStatus, Is.EqualTo(testStatus201));
            });

        }
        [Test]
        public void PUT_Test()
        {
            var testResource = testDomain + testFolder + testId;
            var response = testResource
                .PutJsonAsync(new
                {
                    id = 5,
                    title = "Changed title",
                    body = "Changed body",
                    userId = 121,
                });
            var responseBody = response.Result.ResponseMessage.Content.ReadAsStringAsync().Result;
            var responseStatus = response.Result.StatusCode;

            Assert.Multiple(() =>
            {
                Assert.That(responseBody.GetType(), Is.EqualTo(typeData));
                Assert.That(responseStatus, Is.EqualTo(testStatus200));
            });

        }
        [Test]
        public void PATCH_Test()
        {
            var testResource = testDomain + testFolder + testId;
            var response = testResource
                .PatchJsonAsync(new
                {
                    title = "Completely new title",
                    userId = 155,
                });
            var responseBody = response.Result.ResponseMessage.Content.ReadAsStringAsync().Result;
            var responseStatus = response.Result.StatusCode;

            Assert.Multiple(() =>
            {
                Assert.That(responseBody.GetType(), Is.EqualTo(typeData));
                Assert.That(responseStatus, Is.EqualTo(testStatus200));
            });

        }
        [Test]
        public void DELETE_Test()
        {
            var testResource = testDomain + testFolder + testId;
            var response = testResource.DeleteAsync();
            var responseStatus = response.Result.StatusCode;

            Assert.That(responseStatus, Is.EqualTo(testStatus200));

        }

    }
}