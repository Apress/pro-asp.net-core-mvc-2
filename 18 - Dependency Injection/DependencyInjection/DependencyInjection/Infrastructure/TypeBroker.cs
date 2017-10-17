using DependencyInjection.Models;
using System;

namespace DependencyInjection.Infrastructure {
    public static class TypeBroker {
        private static Type repoType = typeof(MemoryRepository);
        private static IRepository testRepo;

        public static IRepository Repository =>
            testRepo ?? Activator.CreateInstance(repoType) as IRepository;

        public static void SetRepositoryType<T>() where T : IRepository =>
            repoType = typeof(T);

        public static void SetTestObject(IRepository repo) {
            testRepo = repo;
        }
    }
}
