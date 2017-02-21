namespace UmbracoVault
{
    public static class Vault
    {
        private static IUmbracoContext _instance = new UmbracoWebContext();

        /// <summary>
        /// Retrieves an Umbraco Context to be used to generate Vault objects
        /// </summary>
        public static IUmbracoContext Context => _instance;

        public static void SetOverrideContext(IUmbracoContext context)
        {
            _instance = context;
        }
    }
}
