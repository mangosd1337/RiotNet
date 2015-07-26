﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using RiotNet.Models;
using RiotNet.Tests.Properties;

namespace RiotNet.Tests
{
    [TestFixture]
    public class ChampionTests : TestBase
    {
        [Test]
        public async Task GetChampionsTaskAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var champions = await client.GetChampionsTaskAsync();

            Assert.That(champions, Is.Not.Null);
            Assert.That(champions.Count, Is.GreaterThan(100));
        }

        [Test]
        public async Task GetChampionsTaskAsyncTest_FreeToPlay()
        {
            IRiotClient client = new RiotClient();
            var champions = await client.GetChampionsTaskAsync(true);

            Assert.That(champions, Is.Not.Null);
            Assert.That(champions.Count, Is.LessThan(20));
        }

        [Test]
        public async Task GetChampionByIdTaskAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var champion = await client.GetChampionByIdTaskAsync(103);

            Assert.That(champion, Is.Not.Null);
            Assert.That(champion.Id, Is.EqualTo(103));
        }

        [Test]
        public void DeserializeChampionTest()
        {
            var champion = JsonConvert.DeserializeObject<Champion>(Resources.SampleChampion, RiotClient.JsonSettings);

            AssertNonDefaultValuesRecursive(champion);
        }
    }
}