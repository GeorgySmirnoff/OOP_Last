
using NUnit.Framework;
namespace lab_work_third.test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void DistanceReduserTest300()
        {
            KoverSamolet ks = new KoverSamolet();
            double expected = 300;
            double actual = ks.DistanceReducer(300);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CheckWinner1500()
        {
            Race<AirTransport> race = new Race<AirTransport>(1500);

            Metla metla = new Metla();
            Stupa stupa = new Stupa();
            KoverSamolet koverSamolet = new KoverSamolet();

            race.Register(metla);//74
            race.Register(stupa);//176.25
            race.Register(koverSamolet);//145.5

            Transport actual = race.Start();
            Transport expected = metla;

            Assert.AreEqual(expected, actual);
        }
        public void CheckWinner20000()
        {
            Race<AirTransport> race = new Race<AirTransport>(20000);

            Metla metla = new Metla();
            Stupa stupa = new Stupa();
            KoverSamolet koverSamolet = new KoverSamolet();

            race.Register(metla);//800
            race.Register(stupa);//2350
            race.Register(koverSamolet);//1900

            Transport actual = race.Start();
            Transport expected = metla;

            Assert.AreEqual(expected, actual);
        }
    }
}