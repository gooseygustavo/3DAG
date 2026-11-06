using UnityEngine;
namespace RetroStyleGames.StickTogether {
 [ExecuteAlways]
 public sealed class SurvivalShowcaseLabel : MonoBehaviour {
  public Camera viewer;
  public Transform subject;
  float authoredScale;
  void LateUpdate(){
   if(viewer==null)return;transform.rotation=viewer.transform.rotation;
   if(subject==null)return;
   var renderers=subject.GetComponentsInChildren<Renderer>();bool any=false;float maxY=0,maxX=0,minX=1,depth=0;
   foreach(var r in renderers){
    if(r is ParticleSystemRenderer||!r.enabled)continue;var b=r.bounds;
    for(int i=0;i<8;i++){
     var p=viewer.WorldToViewportPoint(b.center+Vector3.Scale(b.extents,new Vector3((i&1)==0?-1:1,(i&2)==0?-1:1,(i&4)==0?-1:1)));
     if(p.z<=viewer.nearClipPlane)continue;any=true;maxY=Mathf.Max(maxY,p.y);minX=Mathf.Min(minX,p.x);maxX=Mathf.Max(maxX,p.x);depth=Mathf.Max(depth,p.z);
    }
   }
   if(!any)return;var rect=GetComponent<RectTransform>();
   float worldHeight=viewer.orthographic?2*viewer.orthographicSize:2*depth*Mathf.Tan(viewer.fieldOfView*Mathf.Deg2Rad*.5f);
   if(authoredScale<=0)authoredScale=transform.localScale.x;
   transform.localScale=Vector3.one*Mathf.Min(authoredScale,worldHeight*viewer.aspect*.28f/(rect?rect.rect.width:320));
   float halfHeight=(rect?rect.rect.height:58)*transform.lossyScale.y*.5f;
   transform.position=viewer.ViewportToWorldPoint(new Vector3((minX+maxX)*.5f,maxY+halfHeight/worldHeight+.008f,depth));
  }
 }
}
