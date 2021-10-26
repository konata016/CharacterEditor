using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeFaceItemsController : FaceItemsControllerBase
{
   protected override void onFinishedEachFaceItemSetup(FaceItem faceItem)
   {
      base.onFinishedEachFaceItemSetup(faceItem);

      faceItem.SetupImageStatus(new Vector2(0, -20), 2.3f);
   }
}
