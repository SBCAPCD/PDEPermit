using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SbcapcdOrg.PdePermit.Forms.Components
{

  //public class GoToEntityEventArgs : EventArgs
  //{
  //  public string EntityType;
  //  public object EntityNo;

  //  public GoToEntityEventArgs(string entityType, object entityNo)
  //  {
  //    EntityType = entityType;
  //    EntityNo = entityNo;
  //  }
  //}

  // Class with a function that creates the eventargs and initiates the event
  //public class GoToEntity
  //{

  //  // Events are handled with delegates, so we must establish a Handler as a delegate:

  //  public delegate void GoToEntityEventHandler(object sender, GoToEntityEventArgs e);

  //  // Now, create a public event "FireEvent" whose type is our FireEventHandler delegate. 

  //  public event GoToEntityEventHandler OnGoToEntity;

  //  // This will be the starting point of our event-- it will create FireEventArgs,
  //  // and then raise the event, passing FireEventArgs. 

  //  public void TriggerGoToEntity(string entityType, object entityNo)
  //  {

  //    GoToEntityEventArgs GoToEntityArgs = new GoToEntityEventArgs(entityType, entityNo);

  //    // Now, raise the event by invoking the delegate. Pass in 
  //    // the object that initated the event (this) as well as FireEventArgs. 
  //    // The call must match the signature of FireEventHandler.

  //    OnGoToEntity(this, GoToEntityArgs);
  //  }
  //}
}
