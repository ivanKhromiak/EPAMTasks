using System;
using System.Collections.Generic;
using System.Reflection;

namespace ReflectionTasks
{
    internal class AssemblyInfo
    {
        internal List<string> GetAssemblyInfo()
        {
            var infoAssembly = new List<string>();
            Assembly assemble = Assembly.GetAssembly(typeof(TasksEnums.Colors));

            infoAssembly.Add(assemble.FullName);
            infoAssembly.Add(assemble.ImageRuntimeVersion);
            infoAssembly.Add(assemble.Location);
            foreach (var module in assemble.GetModules())
            {
                infoAssembly.Add(module.FullyQualifiedName);
                foreach(MemberInfo memberInfo in module.GetFields())
                {
                    infoAssembly.Add(memberInfo.Name);
                }
                foreach (MemberInfo memberInfo in module.GetMethods())
                {
                    infoAssembly.Add(memberInfo.Name);
                }
                foreach (var memberInfo in module.GetTypes())
                {
                    infoAssembly.Add(memberInfo.Name);
                }
            }

            return infoAssembly;
        }
    }
}
