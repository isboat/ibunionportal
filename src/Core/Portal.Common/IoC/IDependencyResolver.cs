namespace Portal.Common.IoC
{
    public interface IDependencyResolver
    {
        /// <summary>Resolves the specified name.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">The name.</param>
        /// <returns>The <see cref="T"/>.</returns>
        T Resolve<T>(string name);

        /// <summary>Resolves this instance.</summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>The <see cref="T"/>.</returns>
        T Resolve<T>();
    
    }
}
