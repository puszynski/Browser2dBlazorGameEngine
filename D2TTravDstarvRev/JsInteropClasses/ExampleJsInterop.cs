﻿using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace D2TTravDstarvRev.JsInteropClasses
{
    public class ExampleJsInterop : IDisposable
    {
        private readonly IJSRuntime _jsRuntime;
        private DotNetObjectReference<HelloHelper> _objRef;

        public ExampleJsInterop(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public ValueTask<string> CallHelloHelperSayHello(string name)
        {
            _objRef = DotNetObjectReference.Create(new HelloHelper(name));

            return _jsRuntime.InvokeAsync<string>(
                "exampleJsFunctions.sayHello",
                _objRef);
        }

        public void Dispose()
        {
            _objRef?.Dispose();
        }
    }

    public class HelloHelper
    {
        public HelloHelper(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        [JSInvokable]
        public string SayHello() => $"Hello, {Name}!";
    }
}
