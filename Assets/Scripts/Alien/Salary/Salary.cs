using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salary {
    private const float transportation = 50f;
    private const float healthCare = 100f;

    private List<Benefit> benefits;

    public Salary(Alien alien) {
        this.benefits = new List<Benefit>();

        GenerateBenefits(alien);
    }

    private void GenerateBenefits(Alien alien) {
        GenerateBaseSalary(alien);
        GenerateTransportation(alien);
        GenerateHealthCare(alien);
    }

    private void GenerateBaseSalary(Alien alien) { //benefits index = 0
        float baseValue = (alien.GetAgility() + alien.GetWisdom())*10;
        benefits.Add(new Benefit("Salário Base", baseValue));
    }

    private void GenerateTransportation(Alien alien) { //benefits index = 1
        Galaxy homeGalaxy = Universe.GetGalaxies(alien.GetGalaxyId());
        Galaxy workGalaxy = Universe.GetGalaxies(alien.GetWorkGalaxyId());
        int workDistance = Universe.GetDistance(homeGalaxy, workGalaxy);

        float transportationValue = transportation * workDistance;

        benefits.Add(new Benefit("Transporte", transportationValue));
    }

    private void GenerateHealthCare(Alien alien) { //benefits index = 2
        float healthCareValue = healthCare - alien.GetStatus();
        benefits.Add(new Benefit("Plano de Saúde", healthCareValue));
    }

    #region Getters

        public List<Benefit> GetBenefits() {
            return benefits;
        }

        public Benefit GetBenefits(int index) {
            return benefits[index];
        }

        public float GetBase() {
            return benefits[0].GetValue();
        }

        public float GetTransportation() {
            return benefits[1].GetValue();
        }

        public float GetHealthCare() {
            return benefits[2].GetValue();
        }

        public float GetFinal() {
            float finalSalary = 0f;

            foreach (Benefit benefit in benefits) {
                finalSalary += benefit.GetValue();
            }

            return finalSalary;
        }

    #endregion
}