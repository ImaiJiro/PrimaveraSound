using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BPMShower : MonoBehaviour
{
    public DJControllerwTracks controller1;
    public DJControllerwTracks controller2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (controller1.Clipname.text)
        {
            case "Loop1":
                controller1.currentbpm = 120;
                break;
            case "Loop2":
                controller1.currentbpm = 125;
                break;
            case "Loop3":
                controller1.currentbpm = 125;
                break;
            case "Loop4":
                controller1.currentbpm = 125;
                break;
            case "Loop5":
                controller1.currentbpm = 125;
                break;
            case "Loop6":
                controller1.currentbpm = 125;
                break;
            case "Loop7":
                controller1.currentbpm = 125;
                break;
            case "Loop8":
                controller1.currentbpm = 125;
                break;
            case "Loop9":
                controller1.currentbpm = 125;
                break;
            case "Loop10":
                controller1.currentbpm = 125;
                break;
            case "Track1":
                controller1.currentbpm = 120;
                break;
            case "Track2":
                controller1.currentbpm = 125;
                break;
            case "Track3":
                controller1.currentbpm = 125;
                break;
            case "Track4":
                controller1.currentbpm = 125;
                break;
            default:
                
                break;
        }
        switch (controller2.Clipname.text)
        {
            case "Loop1":
                controller2.currentbpm = 120;
                break;
            case "Loop2":
                controller2.currentbpm = 125;
                break;
            case "Loop3":
                controller2.currentbpm = 125;
                break;
            case "Loop4":
                controller2.currentbpm = 125;
                break;
            case "Loop5":
                controller2.currentbpm = 125;
                break;
            case "Loop6":
                controller2.currentbpm = 125;
                break;
            case "Loop7":
                controller2.currentbpm = 125;
                break;
            case "Loop8":
                controller2.currentbpm = 125;
                break;
            case "Loop9":
                controller2.currentbpm = 125;
                break;
            case "Loop10":
                controller2.currentbpm = 125;
                break;
            case "Track1":
                controller2.currentbpm = 120;
                break;
            case "Track2":
                controller2.currentbpm = 125;
                break;
            case "Track3":
                controller2.currentbpm = 125;
                break;
            case "Track4":
                controller2.currentbpm = 125;
                break;
            default:
                
                break;
        }

    }
}
