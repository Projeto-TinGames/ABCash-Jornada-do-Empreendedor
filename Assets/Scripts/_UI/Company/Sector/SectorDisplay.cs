using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SectorDisplay : ClickableDisplayUI {
    private Sector sector;

    [SerializeField]private TextMeshProUGUI productText;
    [SerializeField]private TextMeshProUGUI employeesText;
    [SerializeField]private TextMeshProUGUI timeText;

    protected override void Start() {
        base.Start();

        productText.text = $"Produto: {sector.GetProduct().GetName()}";
        employeesText.text = $"Número de empregados: {sector.GetAlienCounter()}";
        timeText.text = "Tempo: Nenhum empregado está produzindo.";
    }

    private void Update() {
        TimeData time = sector.GetRelativeProductionTime();

        if (sector.GetHasAliens()) {
            timeText.text = $"Tempo: {time.GetDays()}d {time.GetHours()}h {time.GetMinutes()}m {time.GetSeconds()}s";
        }
        else {
            timeText.text = "Tempo: Nenhum empregado está produzindo.";
        }
    }

    public override void Select() {}

    public override void Click() {
        EventHandlerUI.setSector.Invoke(sector);

        SectorUI.SetCloseScene("sc_branch");
        SceneController.instance.Load("sc_sector");
    }

    #region Set Functions

        public void SetSector(Sector sector) {
            this.sector = sector;
        }

    #endregion
}