﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Service.Services.Abstracts
{
    public interface IDashboardService
    {
        Task<List<int>> GetYearlyArticleCounts();
        Task<int> GetTotalArticleCount();
        Task<int> GetTotalCategoryCount();
        Task<int> GetTotalUserArticlesCount();
        Task<int> GetTotalUserCategoriesCount();
        Task<string> LoginUserName();
    }
}
