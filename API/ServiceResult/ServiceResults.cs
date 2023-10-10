﻿namespace API.ServiceResult
{
    public class ServiceResults<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}
