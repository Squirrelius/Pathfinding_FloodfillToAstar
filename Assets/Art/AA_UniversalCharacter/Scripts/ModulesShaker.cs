/////////////////////////////////////////////
//// Codewart Game Assets 2021
//// ModulesShaker.cs
//// Description: Set or randomize elements of characters within or between our modular packages
//// License: Use or modify as you need
//// Contact: support@codewart.com
//// Unity Asset Store: https://assetstore.unity.com/publishers/49258
/////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModulesShaker : MonoBehaviour {

    [Header("Package details:")]
    [Space]
    public string package_mark = "AA";//Package unique mark
    public int first_set_number = 0; //Naked element
    public int last_set_number = 10; //Last number of preset

    [Space]
    public string set_numeration = "001"; //Preset numeration you want to apply

    [HideInInspector]
    public string[] Gender = new string[] {"Male","Female"};
    [HideInInspector]
    public int gender_idx = 0;

    [Space]

    [Header("Other modular packages:")]

    public string[] other_packages = new string[] { };

    [Space]

    [Space]

    [Header("Body elements:")]

    [Space]

    //Unisex elements
    public GameObject unisex_belt;
    public GameObject unisex_cape;
    public GameObject unisex_elbow_l;
    public GameObject unisex_elbow_r;
    public GameObject unisex_eyebrows;
    public GameObject unisex_knee_l;
    public GameObject unisex_knee_r;
    public GameObject unisex_pauldron_l;
    public GameObject unisex_pauldron_r;

    //Female elements
    public GameObject arm_f_l;
    public GameObject arm_f_r;
    public GameObject calf_f_l;
    public GameObject calf_f_r;
    public GameObject foot_f_l;
    public GameObject foot_f_r;
    public GameObject forearm_f_l;
    public GameObject forearm_f_r;
    public GameObject hair_f;
    public GameObject hand_f_l;
    public GameObject hand_f_r;
    public GameObject head_f;
    public GameObject legs_f;
    public GameObject torso_f;

    //Male elements
    public GameObject arm_m_l;
    public GameObject arm_m_r;
    public GameObject calf_m_l;
    public GameObject calf_m_r;
    public GameObject facial_hair;
    public GameObject foot_m_l;
    public GameObject foot_m_r;
    public GameObject forearm_m_l;
    public GameObject forearm_m_r;
    public GameObject hair_m;
    public GameObject hand_m_l;
    public GameObject hand_m_r;
    public GameObject head_m;
    public GameObject legs_m;
    public GameObject torso_m;


    public void SetAll(string numeration)
    {
        SetElement("Belt",numeration);
        SetElement("Cape", numeration);
        SetElement("Elbow_L", numeration);
        SetElement("Elbow_R", numeration);
        SetElement("Eyebrows", numeration);
        SetElement("Knee_L", numeration);
        SetElement("Knee_R", numeration);
        SetElement("Pauldron_L", numeration);
        SetElement("Pauldron_R", numeration);

        SetElement("Arm_"+ getGender()+"_L",numeration);
        SetElement("Arm_" + getGender() + "_R", numeration);
        SetElement("Calf_" + getGender() + "_L", numeration);
        SetElement("Calf_" + getGender() + "_R", numeration);
        if (getGender() == "M")
        {
            SetElement("Facial_Hair", numeration);
        }
        else {
            facial_hair.SetActive(false);
        }
        SetElement("Foot_" + getGender() + "_L", numeration);
        SetElement("Foot_" + getGender() + "_R", numeration);
        SetElement("Forearm_" + getGender() + "_L", numeration);
        SetElement("Forearm_" + getGender() + "_R", numeration);
        SetElement("Hair_" + getGender(), numeration);
        SetElement("Hand_" + getGender() + "_L", numeration);
        SetElement("Hand_" + getGender() + "_R", numeration);
        SetElement("Head_" + getGender(), numeration);
        SetElement("Legs_" + getGender(), numeration);
        SetElement("Torso_" + getGender(), numeration);

    }
    
    public void RandomizeAll()
    {
        SetElement("Belt", getRandomNumeration());
        SetElement("Cape", getRandomNumeration());
        SetElement("Elbow_L", getRandomNumeration());
        SetElement("Elbow_R", getRandomNumeration());
        SetElement("Eyebrows", getRandomNumeration());
        SetElement("Knee_L", getRandomNumeration());
        SetElement("Knee_R", getRandomNumeration());
        SetElement("Pauldron_L", getRandomNumeration());
        SetElement("Pauldron_R", getRandomNumeration());

        SetElement("Arm_" + getGender() + "_L", getRandomNumeration());
        SetElement("Arm_" + getGender() + "_R", getRandomNumeration());
        SetElement("Calf_" + getGender() + "_L", getRandomNumeration());
        SetElement("Calf_" + getGender() + "_R", getRandomNumeration());
        if (getGender() == "M")
        {
            SetElement("Facial_Hair", getRandomNumeration());
        }
        else
        {
            facial_hair.SetActive(false);
        }
        SetElement("Foot_" + getGender() + "_L", getRandomNumeration());
        SetElement("Foot_" + getGender() + "_R", getRandomNumeration());
        SetElement("Forearm_" + getGender() + "_L", getRandomNumeration());
        SetElement("Forearm_" + getGender() + "_R", getRandomNumeration());
        SetElement("Hair_" + getGender(), getRandomNumeration());
        SetElement("Hand_" + getGender() + "_L", getRandomNumeration());
        SetElement("Hand_" + getGender() + "_R", getRandomNumeration());
        SetElement("Head_" + getGender(), getRandomNumeration());
        SetElement("Legs_" + getGender(), getRandomNumeration());
        SetElement("Torso_" + getGender(), getRandomNumeration());

    }
    public void RandomizeAllOther()
    {
        if (other_packages.Length == 0)
        {
            Debug.LogError("No other package reference marks in section 'Other_packages'");
            return;
        }

        SetElement("Belt", getRandomNumeration(),true);
        SetElement("Cape", getRandomNumeration(),true);
        SetElement("Elbow_L", getRandomNumeration(), true);
        SetElement("Elbow_R", getRandomNumeration(), true);
        SetElement("Eyebrows", getRandomNumeration(), true);
        SetElement("Knee_L", getRandomNumeration(), true);
        SetElement("Knee_R", getRandomNumeration(), true);
        SetElement("Pauldron_L", getRandomNumeration(), true);
        SetElement("Pauldron_R", getRandomNumeration(), true);

        SetElement("Arm_" + getGender() + "_L", getRandomNumeration(), true);
        SetElement("Arm_" + getGender() + "_R", getRandomNumeration(), true);
        SetElement("Calf_" + getGender() + "_L", getRandomNumeration(), true);
        SetElement("Calf_" + getGender() + "_R", getRandomNumeration(), true);
        if (getGender() == "M")
        {
            SetElement("Facial_Hair", getRandomNumeration(),true);
        }
        else
        {
            facial_hair.SetActive(false);
        }
        SetElement("Foot_" + getGender() + "_L", getRandomNumeration(), true);
        SetElement("Foot_" + getGender() + "_R", getRandomNumeration(), true);
        SetElement("Forearm_" + getGender() + "_L", getRandomNumeration(), true);
        SetElement("Forearm_" + getGender() + "_R", getRandomNumeration(), true);
        SetElement("Hair_" + getGender(), getRandomNumeration(), true);
        SetElement("Hand_" + getGender() + "_L", getRandomNumeration(), true);
        SetElement("Hand_" + getGender() + "_R", getRandomNumeration(), true);
        SetElement("Head_" + getGender(), getRandomNumeration(), true);
        SetElement("Legs_" + getGender(), getRandomNumeration(), true);
        SetElement("Torso_" + getGender(), getRandomNumeration(), true);

    }
    public void SetElement(string element, string numeration, bool random = false) {

        SkinnedMeshRenderer smr = null;
        string from_package = package_mark;
        string smr_name = "";
        //Debug.Log("Set element: "+element+" "+numeration);

        //unisex
        if (element == "Belt")
        {
            smr = unisex_belt.GetComponent<SkinnedMeshRenderer>();
        }
        else if (element == "Cape")
        {
            smr = unisex_cape.GetComponent<SkinnedMeshRenderer>();
        }
        else if (element == "Elbow_L")
        {
            smr = unisex_elbow_l.GetComponent<SkinnedMeshRenderer>();
        }
        else if (element == "Elbow_R")
        {
            smr = unisex_elbow_r.GetComponent<SkinnedMeshRenderer>();
        }
        else if (element == "Eyebrows")
        {
            smr = unisex_eyebrows.GetComponent<SkinnedMeshRenderer>();
        }
        else if (element == "Knee_L")
        {
            smr = unisex_knee_l.GetComponent<SkinnedMeshRenderer>();
        }
        else if (element == "Knee_R")
        {
            smr = unisex_knee_r.GetComponent<SkinnedMeshRenderer>();
        }
        else if (element == "Pauldron_L")
        {
            smr = unisex_pauldron_l.GetComponent<SkinnedMeshRenderer>();
        }
        else if (element == "Pauldron_R")
        {
            smr = unisex_pauldron_r.GetComponent<SkinnedMeshRenderer>();
        }
        //female
        else if (element == "Arm_F_L")
        {
            smr = arm_f_l.GetComponent<SkinnedMeshRenderer>();
            arm_f_l.SetActive(true);
            arm_m_l.SetActive(false);
        }
        else if (element == "Arm_F_R")
        {
            smr = arm_f_r.GetComponent<SkinnedMeshRenderer>();
            arm_f_r.SetActive(true);
            arm_m_r.SetActive(false);
        }
        else if (element == "Calf_F_L")
        {
            smr = calf_f_l.GetComponent<SkinnedMeshRenderer>();
            calf_f_l.SetActive(true);
            calf_m_l.SetActive(false);
        }
        else if (element == "Calf_F_R")
        {
            smr = calf_f_r.GetComponent<SkinnedMeshRenderer>();
            calf_f_r.SetActive(true);
            calf_m_r.SetActive(false);
        }
        else if (element == "Foot_F_L")
        {
            smr = foot_f_l.GetComponent<SkinnedMeshRenderer>();
            foot_f_l.SetActive(true);
            foot_m_l.SetActive(false);
        }
        else if (element == "Foot_F_R")
        {
            smr = foot_f_r.GetComponent<SkinnedMeshRenderer>();
            foot_f_r.SetActive(true);
            foot_m_r.SetActive(false);
        }
        else if (element == "Forearm_F_L")
        {
            smr = forearm_f_l.GetComponent<SkinnedMeshRenderer>();
            forearm_f_l.SetActive(true);
            forearm_m_l.SetActive(false);
        }
        else if (element == "Forearm_F_R")
        {
            smr = forearm_f_r.GetComponent<SkinnedMeshRenderer>();
            forearm_f_r.SetActive(true);
            forearm_m_r.SetActive(false);
        }
        else if (element == "Hair_F")
        {
            smr = hair_f.GetComponent<SkinnedMeshRenderer>();
            hair_f.SetActive(true);
            hair_m.SetActive(false);
        }
        else if (element == "Hand_F_L")
        {
            smr = hand_f_l.GetComponent<SkinnedMeshRenderer>();
            hand_f_l.SetActive(true);
            hand_m_l.SetActive(false);
        }
        else if (element == "Hand_F_R")
        {
            smr = hand_f_r.GetComponent<SkinnedMeshRenderer>();
            hand_f_r.SetActive(true);
            hand_m_r.SetActive(false);
        }
        else if (element == "Head_F")
        {
            smr = head_f.GetComponent<SkinnedMeshRenderer>();
            head_f.SetActive(true);
            head_m.SetActive(false);
        }
        else if (element == "Legs_F")
        {
            smr = legs_f.GetComponent<SkinnedMeshRenderer>();
            legs_f.SetActive(true);
            legs_m.SetActive(false);
        }
        else if (element == "Torso_F")
        {
            smr = torso_f.GetComponent<SkinnedMeshRenderer>();
            torso_f.SetActive(true);
            torso_m.SetActive(false);
        }
        //male
        else if (element == "Arm_M_L")
        {
            smr = arm_m_l.GetComponent<SkinnedMeshRenderer>();
            arm_f_l.SetActive(false);
            arm_m_l.SetActive(true);
        }
        else if (element == "Arm_M_R")
        {
            smr = arm_m_r.GetComponent<SkinnedMeshRenderer>();
            arm_f_r.SetActive(false);
            arm_m_r.SetActive(true);
        }
        else if (element == "Calf_M_L")
        {
            smr = calf_m_l.GetComponent<SkinnedMeshRenderer>();
            calf_f_l.SetActive(false);
            calf_m_l.SetActive(true);
        }
        else if (element == "Calf_M_R")
        {
            smr = calf_m_r.GetComponent<SkinnedMeshRenderer>();
            calf_f_r.SetActive(false);
            calf_m_r.SetActive(true);
        }
        else if (element == "Facial_Hair")
        {
            smr = facial_hair.GetComponent<SkinnedMeshRenderer>();
            facial_hair.SetActive(true);
        }
        else if (element == "Foot_M_L")
        {
            smr = foot_m_l.GetComponent<SkinnedMeshRenderer>();
            foot_f_l.SetActive(false);
            foot_m_l.SetActive(true);
        }
        else if (element == "Foot_M_R")
        {
            smr = foot_m_r.GetComponent<SkinnedMeshRenderer>();
            foot_f_r.SetActive(false);
            foot_m_r.SetActive(true);
        }
        else if (element == "Forearm_M_L")
        {
            smr = forearm_m_l.GetComponent<SkinnedMeshRenderer>();
            forearm_f_l.SetActive(false);
            forearm_m_l.SetActive(true);
        }
        else if (element == "Forearm_M_R")
        {
            smr = forearm_m_r.GetComponent<SkinnedMeshRenderer>();
            forearm_f_r.SetActive(false);
            forearm_m_r.SetActive(true);
        }
        else if (element == "Hair_M")
        {
            smr = hair_m.GetComponent<SkinnedMeshRenderer>();
            hair_f.SetActive(false);
            hair_m.SetActive(true);
        }
        else if (element == "Hand_M_L")
        {
            smr = hand_m_l.GetComponent<SkinnedMeshRenderer>();
            hand_f_l.SetActive(false);
            hand_m_l.SetActive(true);
        }
        else if (element == "Hand_M_R")
        {
            smr = hand_m_r.GetComponent<SkinnedMeshRenderer>();
            hand_f_r.SetActive(false);
            hand_m_r.SetActive(true);
        }
        else if (element == "Head_M")
        {
            smr = head_m.GetComponent<SkinnedMeshRenderer>();
            head_f.SetActive(false);
            head_m.SetActive(true);
        }
        else if (element == "Legs_M")
        {
            smr = legs_m.GetComponent<SkinnedMeshRenderer>();
            legs_f.SetActive(false);
            legs_m.SetActive(true);
        }
        else if (element == "Torso_M")
        {
            smr = torso_m.GetComponent<SkinnedMeshRenderer>();
            torso_f.SetActive(false);
            torso_m.SetActive(true);
        }

        if (random == true)
        {
            from_package = getRandomOtherPackage();
        }    

        smr_name = element + "_" + from_package + "_" + numeration;

        if (smr != null)
        {
            smr.sharedMesh = findMesh(smr_name);
            if (smr.sharedMesh == null)
            {
                //element not found,deactivate branch if not unisex
                if (numeration != "000")
                {
                    smr.gameObject.SetActive(false);
                }
            }
            else {
                smr.gameObject.SetActive(true);
            }
        }
        else
        {
            Debug.LogError("SkinnedMeshRenderer Not found! Check game object assignment or make sure that element exist");
        }
    }
    private string getRandomOtherPackage()
    {
        string ret = "";
        int otherPackagesCount = other_packages.Length;
        int random = UnityEngine.Random.Range(0, otherPackagesCount);

        ret = other_packages[random];

        return ret;
    }
    private string getRandomNumeration()
    {
        string ret = "";
        int random = UnityEngine.Random.Range(first_set_number, last_set_number+1);
        if (random < 10)
        {
            ret = "00" + random.ToString();
        }
        else
        {
            ret = "0" + random.ToString();
        }
        return ret;
    }
    private string getGender() {
        if (gender_idx == 0)
        {
            return "M";
        }
        else {
            return "F";
        }
    }
    private Mesh findMesh(string meshName)
    {
        Mesh[] meshes = Resources.FindObjectsOfTypeAll<Mesh>();
        Mesh ret = null;

        for (int i = 0; i < meshes.Length; i++)
        {
            if (meshes[i].name == meshName)
            {
                //Debug.Log(meshes[i].name);
                ret = meshes[i];
                break;
            }
        }

        if (ret == null)
        {
            Debug.LogWarning("Mesh "+meshName+" not found! Make sure the object should exist or it has at least one instance on the stage");
        }

        return ret;

    }
}
