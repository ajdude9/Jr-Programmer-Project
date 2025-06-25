using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Design;
using UnityEngine;

/// <summary>
/// A subclass of Building that produce resource at a constant rate.
/// </summary>
public class ResourcePile : Building
{
    public ResourceItem Item;

    private float m_productionSpeed = 0.5f;
    public float productionSpeed
    {
        get { return m_productionSpeed;  }//get returns the 'backing field'
        set
        {
            if (value < 0.0f)//Make sure the value attemtping to be set isn't less than 0, which is not allowed
            {
                Debug.LogError("Production Speed cannot be a negative number.");
            }
            else
            {
                m_productionSpeed = value;//Original setter script
            }

        }//set uses the 'backing field'
    }

    private float m_CurrentProduction = 0.0f;

    private void Update()
    {
        if (m_CurrentProduction > 1.0f)
        {
            int amountToAdd = Mathf.FloorToInt(m_CurrentProduction);
            int leftOver = AddItem(Item.Id, amountToAdd);

            m_CurrentProduction = m_CurrentProduction - amountToAdd + leftOver;
        }
        
        if (m_CurrentProduction < 1.0f)
        {
            m_CurrentProduction += m_productionSpeed * Time.deltaTime;
        }
    }

    public override string GetData()
    {
        return $"Producing at the speed of {m_productionSpeed}/s";
        
    }
    
    
}
