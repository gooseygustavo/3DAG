using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif
namespace RetroStyleGames.StickTogether {
public sealed class SurvivalShowcaseCamera : MonoBehaviour {
 public float speed=4,lookSpeed=2;public Transform[] inspectionViews=new Transform[0];Vector3 start;Quaternion rotation;int viewIndex=-1;
 void Start(){start=transform.position;rotation=transform.rotation;}
 void Update(){Vector3 move=Vector3.zero;Vector2 look=Vector2.zero;bool held=false,fast=false,reset=false;
#if ENABLE_INPUT_SYSTEM
 var k=Keyboard.current;var m=Mouse.current;if(k!=null){move=new Vector3((k.dKey.isPressed?1:0)-(k.aKey.isPressed?1:0),(k.eKey.isPressed?1:0)-(k.qKey.isPressed?1:0),(k.wKey.isPressed?1:0)-(k.sKey.isPressed?1:0));fast=k.leftShiftKey.isPressed;reset=k.rKey.wasPressedThisFrame;}if(m!=null){held=m.rightButton.isPressed;look=m.delta.ReadValue()*.08f;}
#elif ENABLE_LEGACY_INPUT_MANAGER
 move=new Vector3((Input.GetKey(KeyCode.D)?1:0)-(Input.GetKey(KeyCode.A)?1:0),(Input.GetKey(KeyCode.E)?1:0)-(Input.GetKey(KeyCode.Q)?1:0),(Input.GetKey(KeyCode.W)?1:0)-(Input.GetKey(KeyCode.S)?1:0));held=Input.GetMouseButton(1);look=new Vector2(Input.GetAxis("Mouse X"),Input.GetAxis("Mouse Y"));fast=Input.GetKey(KeyCode.LeftShift);reset=Input.GetKeyDown(KeyCode.R);
#endif
 bool next=false;
#if ENABLE_INPUT_SYSTEM
 next=Keyboard.current!=null&&Keyboard.current.tabKey.wasPressedThisFrame;
#elif ENABLE_LEGACY_INPUT_MANAGER
 next=Input.GetKeyDown(KeyCode.Tab);
#endif
 if(held){transform.position+=transform.TransformDirection(move)*speed*(fast?3:1)*Time.deltaTime;transform.Rotate(Vector3.up,look.x*lookSpeed,Space.World);transform.Rotate(Vector3.right,-look.y*lookSpeed,Space.Self);}
 if(next&&inspectionViews.Length>0){viewIndex=(viewIndex+1)%(inspectionViews.Length+1);if(viewIndex==inspectionViews.Length)reset=true;else if(inspectionViews[viewIndex]!=null)transform.SetPositionAndRotation(inspectionViews[viewIndex].position,inspectionViews[viewIndex].rotation);}
 if(reset)transform.SetPositionAndRotation(start,rotation);
 }
 void OnGUI(){GUI.Box(new Rect(12,12,390,28),inspectionViews.Length>0?"RMB + WASD / QE   |   Tab: detail view   |   R: overview":"RMB + WASD / QE   |   Shift: faster   |   R: reset");}
}
}
