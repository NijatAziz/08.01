using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    internal class Course
    {
        public string Name;
        public Group[] groups=new Group[0];


        public void AddGroup(Group group)
        {
            Array.Resize(ref groups, groups.Length+1);
            groups[groups.Length-1] = group;
        }
        public Group GetGroupByNo(string no)
        {
            foreach (Group group in groups)
            {
                if(group.GroupNo == no)
                {
                    return group;
                }
            }
            return null;
           
        }
        public Group[] GetGroupsByPoint(double minpoint, double maxpoint)
        {
            Group[] groupsInRange = new Group[0];

            foreach (Group group in groups) 
            { 
                if(group.Point>=minpoint && group.Point <= maxpoint)
                {
                    Array.Resize(ref groupsInRange,groupsInRange.Length+1);
                    groupsInRange[groupsInRange.Length - 1] = group;
                }
            }
            return groupsInRange;   
            
          
        }
    }
}
