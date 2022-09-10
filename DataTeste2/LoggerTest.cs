using Domain.Entity.Util;
using Repository.Util;


namespace DataTeste2
{
    public class LoggerTest
    {
        Data.Context.DbSilasContext _db;
        LoggerRepository _loggerRepository;

        public LoggerTest()
        {
            _db = new Data.Context.DbSilasContext();
            _loggerRepository = new LoggerRepository(_db);
        }

        [Fact]
        public void GetAll()
        {
            var get = _loggerRepository.GetAll();
            Assert.True(get.IsCompleted);
        }
        [Fact]
        public void GetById()
        {
            var get = _loggerRepository.GetAll().Result.Where(x => x.Id == Guid.Parse("E3C71376-73AA-44EA-174A-08DA647665CA")).FirstOrDefault();
            Assert.True(get.Id.ToString().ToUpper() == "E3C71376-73AA-44EA-174A-08DA647665CA");
        }

        [Fact]
        public void AddLog()
        {
            var result = _loggerRepository.SetLogger(new Logger
            {

                ApplicationOwner = "Silas",
                DateTime = DateTime.Now,
                Ambient = "dev",
                ApplicationName = "DataTeste2",
                ApplicationVersion = "1.0.0.0",
                CallerMemberName = "SetLogger",
                Description = "Teste",
                EventId = 0,
                Exception = null,
                InnerException = null,
                Line = 1,
                Server = "SilasPc",
                Stack = null,
                Type = 1
            });
            Assert.True(result.IsCompleted);
        }
    }
}
