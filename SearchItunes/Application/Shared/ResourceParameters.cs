﻿namespace SearchItunes.Application.Shared
{
    public class ResourceParameters
    {
        private const int MaxPageSize = 100;

        private int _pageSize = 25;

        public string SearchTerm { get; set; }
        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }

        public string SortBy { get; set; } = "Id";
    }
}