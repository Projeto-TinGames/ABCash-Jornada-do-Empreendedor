using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SectorDisplay : MonoBehaviour {
    private Sector sector;

    [SerializeField]private TextMeshProUGUI productText;
    [SerializeField]private TextMeshProUGUI employeesText;
    [SerializeField]private TextMeshProUGUI timeText;

    private void Start() {
        productText.text = $"Produto: {sector.GetProduct().GetName()}";
        employeesText.text = $"Número de empregados: {sector.GetAliens().Count}";
        timeText.text = "Tempo: Nenhum empregado está produzindo.";
    }

    private void Update() {
        TimeConverter time = new TimeConverter(sector.GetProductionTimeCounter());

        if (sector.GetAliens().Count > 0) {
            timeText.text = $"Tempo: {time.GetDays()}d {time.GetHours()}h {time.GetMinutes()}m {time.GetSeconds()}s";
        }
        else {
            timeText.text = "Tempo: Nenhum empregado está produzindo.";
        }
    }

    public void ChooseSector() {
        SectorUI.chooseSectorEvent.Invoke(sector);
    }

    #region Set Functions

        public void SetSector(Sector sector) {
            this.sector = sector;
        }

    #endregion
}
