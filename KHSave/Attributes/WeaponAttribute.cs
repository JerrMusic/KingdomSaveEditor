/*
    Kingdom Save Editor
    Copyright (C) 2020 Luciano Ciccariello

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

namespace KHSave.Attributes
{
    public class WeaponAttribute : InfoAttribute
    {
        public WeaponAttribute(string name = null) :
            base(name)
        { }
    }

    public class WeaponCloudAttribute : WeaponAttribute
    {
        public WeaponCloudAttribute(string name = null) :
            base(name)
        { }
    }

    public class WeaponBarretAttribute : WeaponAttribute
    {
        public WeaponBarretAttribute(string name = null) :
            base(name)
        { }
    }

    public class WeaponTifaAttribute : WeaponAttribute
    {
        public WeaponTifaAttribute(string name = null) :
            base(name)
        { }
    }

    public class WeaponAerithAttribute : WeaponAttribute
    {
        public WeaponAerithAttribute(string name = null) :
            base(name)
        { }
    }

    public class WeaponYuffieAttribute : WeaponAttribute
    {
        public WeaponYuffieAttribute(string name = null) :
            base(name)
        { }
    }

    public class WeaponSononAttribute : WeaponAttribute
    {
        public WeaponSononAttribute(string name = null) :
            base(name)
        { }
    }
}
