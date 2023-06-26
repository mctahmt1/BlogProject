namespace BlogProject.Web.ResultMessages
{
    public static class Messages
    {
        public static class Article
        {
            public static string Add(string articleTitle)
            {
                return $"{articleTitle} isminde ki makaleniz başarıyla eklenmiştir.";
            }
            public static string Update(string articleTitle)
            {
                return $"{articleTitle} isminde ki makaleniz başarıyla güncellenmiştir.";
            }
            public static string SafeDelete(string articleTitle)
            {
                return $"{articleTitle} isminde ki makaleniz silinen makaleler klasörüne taşınmıştır.";
            }
            public static string Delete(string articleTitle)
            {
                return $"{articleTitle} isminde ki makale kalıcı olarak silinmiştir.";
            }
            public static string UndoDelete(string articleTitle)
            {
                return $"{articleTitle} isminde ki makale geri yüklenmiştir.";
            }
        }
        public static class Category
        {
            public static string Add(string categoryName)
            {
                return $"{categoryName} isminde ki Kategori başarıyla eklenmiştir.";
            }
            public static string Update(string categoryName)
            {
                return $"{categoryName} isminde ki Kategori başarıyla güncellenmiştir.";
            }
            public static string SafeDelete(string categoryName)
            {
                return $"{categoryName} isminde ki Kategori silinen kategoriler klasörüne taşınmıştır.";
            }
            public static string Delete(string categoryName)
            {
                return $"{categoryName} isminde ki Kategori kalıcı olarak silinmiştir.";
            }
            public static string UndoDelete(string categoryName)
            {
                return $"{categoryName} isminde ki kategori geri yüklenmiştir.";
            }
        }
        public static class User
        {
            public static string Add(string userName)
            {
                return $"{userName} email adresli kullanıcı başarıyla eklenmiştir.";
            }
            public static string Update(string userName)
            {
                return $"{userName} email adresli kullanıcı başarıyla güncellenmiştir.";
            }
            public static string SafeDelete(string userName)
            {
                return $"{userName} email adresli kullanıcı silinen kullanıcılar klasörüne taşınmıştır.";
            }
            public static string Delete(string userName)
            {
                return $"{userName} email adresli kullanıcı kalıcı olarak silinmiştir.";
            }
        }
    }
}
