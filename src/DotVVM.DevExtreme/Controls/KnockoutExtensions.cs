﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;

namespace DotVVM.DevExtreme.Controls
{
    public static class KnockoutExtensions
    {
        public static void AddNegation(this KnockoutBindingGroup group, string name, DotvvmControl control, DotvvmProperty property, Func<bool> nullBindingAction)
        {
            var binding = control.GetValueBinding(property);
            if (binding == null)
            {
                group.Add(name, (!nullBindingAction()).ToString().ToLower());
            }
            else
            {
                string expression = control.GetValueBinding(property).GetKnockoutBindingExpression();
                group.Add(name, $"!{expression}()");
            }
        }

        public static void AddExtender(this KnockoutBindingGroup group, string name, DotvvmControl control, DotvvmProperty property, string extenderName)
        {
            var binding = control.GetValueBinding(property);
            if (binding == null)
            {
                throw new NotSupportedException();
                //group.Add(name, (!nullBindingAction()).ToString().ToLower());
            }
            else
            {
                string expression = control.GetValueBinding(property).GetKnockoutBindingExpression();
                group.Add(name, $"{expression}.{extenderName}");
            }
        }
    }
}
