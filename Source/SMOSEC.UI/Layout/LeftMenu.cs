using System;
using SMOSEC.UI.AssetsManager;
using SMOSEC.UI.MasterData;
using SMOSEC.UI.UserInfo;
using Smobiler.Core.Controls;
using SMOSEC.UI.ConsumablesManager;
using SMOSEC.UI.Department;

namespace SMOSEC.UI.Layout
{
    ////ToolboxItem���ڿ����Ƿ�����Զ���ؼ��������䣬true��ӣ�false�����
    //[System.ComponentModel.ToolboxItem(true)]
    partial class LeftMenu : Smobiler.Core.Controls.MobileUserControl
    {
        /// <summary>
        /// ��ʾ�̶��ʲ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SNAssetsManager_Press(object sender, EventArgs e)
        {
            if (SNAssets.Visible)
            {
                lblSNAssetsManager.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                lblSNAssetsShow.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                imgSNAssets.ResourceID = "zichan1";
                SNAssets.Visible = false;
                SNJieyong.Visible = false;
                SNGuiHuan.Visible = false;
                SNLingYong.Visible = false;
                SNTuiKu.Visible = false;
                SNDiaoBo.Visible = false;
                SNWeiXiu.Visible = false;
                SNBaoFei.Visible = false;
                SNPanDian.Visible = false;
                SNZiChanFenLei.Visible = false;
                SNQuYu.Visible = false;
                SNBuMen.Visible = false;
                lblSNAssetsShow.Text = ">";
            }
            else
            {
                lblSNAssetsManager.ForeColor = System.Drawing.Color.FromArgb(93, 155, 251);
                lblSNAssetsShow.ForeColor = System.Drawing.Color.FromArgb(93, 155, 251);
                imgSNAssets.ResourceID = "zichan2";
                lblConsumables.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                lblConsumablesShow.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                imgConsumables.ResourceID = "haocai1";
                SNAssets.Visible = true;
                SNJieyong.Visible = true;
                SNGuiHuan.Visible = true;
                SNLingYong.Visible = true;
                SNTuiKu.Visible = true;
                SNWeiXiu.Visible = true;
                SNBaoFei.Visible = true;
                lblSNAssetsShow.Text = "��";
                switch (Client.Session["Role"].ToString())
                {
                    case "SMOSECAdmin":
                        SNDiaoBo.Visible = true;
                        SNPanDian.Visible = true;
                        break;
                    case "ADMIN":
                        SNDiaoBo.Visible = true;
                        SNPanDian.Visible = true;
                        SNZiChanFenLei.Visible = true;
                        SNQuYu.Visible = true;
                        SNBuMen.Visible = true;
                        break;
                }
            }
        }
        /// <summary>
        /// ��ת���ʲ��б����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SNAssets_Press(object sender, EventArgs e)
        {
            frmAssets frm = new frmAssets();
            Form.Show(frm);
        }
        /// <summary>
        /// ��ת���ʲ����ý���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SNJieyong_Press(object sender, EventArgs e)
        {
            frmBorrowOrder frm = new frmBorrowOrder();
            Form.Show(frm);
        }
        /// <summary>
        /// ��ת���ʲ��黹����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SNGuiHuan_Press(object sender, EventArgs e)
        {
            frmReturnOrder frm = new frmReturnOrder();
            Form.Show(frm);
        }
        /// <summary>
        /// ��ת���ʲ����ý���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SNLingYong_Press(object sender, EventArgs e)
        {
            frmCollarOrder frm = new frmCollarOrder();
            Form.Show(frm);
        }
        /// <summary>
        /// ��ת���ʲ��˿����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SNTuiKu_Press(object sender, EventArgs e)
        {
            frmRestoreOrder frm = new frmRestoreOrder();
            Form.Show(frm);
        }
        /// <summary>
        /// �̶��ʲ���������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SNDiaoBo_Press(object sender, EventArgs e)
        {
            frmTransferRowsSN frm = new frmTransferRowsSN();
            this.Form.Show(frm);
        }
        /// <summary>
        /// �̶��ʲ����޽���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SNWeiXiu_Press(object sender, EventArgs e)
        {
            frmRepairRowsSN frm = new frmRepairRowsSN();
            this.Form.Show(frm);
        }
        /// <summary>
        /// �̶��ʲ����Ͻ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SNBaoFei_Press(object sender, EventArgs e)
        {
            frmScrapRowsSN frm = new frmScrapRowsSN();
            this.Form.Show(frm);
        }
        /// <summary>
        /// ��ת���ʲ��̵����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SNInventory_Press(object sender, EventArgs e)
        {
            frmAssInventory frm = new frmAssInventory();
            this.Form.Show(frm);
        }
        /// <summary>
        /// ��ת���ʲ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SNZiChanFenLei_Press(object sender, EventArgs e)
        {
            frmAssetsTypeRows frm = new frmAssetsTypeRows();
            Form.Show(frm);
        }
        /// <summary>
        /// ��ת���������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SNQuYu_Press(object sender, EventArgs e)
        {
            frmLocationRows frm = new frmLocationRows();
            Form.Show(frm);
        }
        /// <summary>
        /// ��ת�����Ž���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SNBuMen_Press(object sender, EventArgs e)
        {
            frmDepartment frm = new frmDepartment();
            Form.Show(frm);
        }
        /// <summary>
        /// ��ʾ�ĲĹ�������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Assets_Press(object sender, EventArgs e)
        {
            if (DiaoBo.Visible)
            {
                lblConsumables.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                lblConsumablesShow.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                imgConsumables.ResourceID = "haocai1";
                DiaoBo.Visible = false;
                HaoCai.Visible = false;
                ruku.Visible = false;
                chuku.Visible = false;
                pandian.Visible = false;
                lblConsumablesShow.Text = ">";
            }
            else
            {
                lblConsumables.ForeColor = System.Drawing.Color.FromArgb(93, 155, 251);
                lblConsumablesShow.ForeColor = System.Drawing.Color.FromArgb(93, 155, 251);
                imgConsumables.ResourceID = "haocai2";
                lblSNAssetsManager.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                lblSNAssetsShow.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                imgSNAssets.ResourceID = "zichan1";
                HaoCai.Visible = true;
                ruku.Visible = true;
                chuku.Visible = true;
                lblConsumablesShow.Text = "��";
                if (Client.Session["Role"].ToString() == "SMOSECUser")
                {
                    DiaoBo.Visible = false;
                    pandian.Visible = false;
                }
                else
                {
                    DiaoBo.Visible = true;
                    pandian.Visible = true;
                }

            }
        }
        /// <summary>
        /// �Ĳ��б�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HaoCai_Press(object sender, EventArgs e)
        {
            frmConsumables frm = new frmConsumables();
            Form.Show(frm);
        }
        /// <summary>
        /// ��ⵥ�б�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ruku_Press(object sender, EventArgs e)
        {
            frmWarehouseReceipt frm = new frmWarehouseReceipt();
            Form.Show(frm);
        }
        /// <summary>
        /// ���ⵥ�б�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chuku_Press(object sender, EventArgs e)
        {
            frmOutboundOrder frm = new frmOutboundOrder();
            Form.Show(frm);
        }
        /// <summary>
        /// ��ת���Ĳĵ�������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiaoBo_Press(object sender, EventArgs e)
        {
            frmTransferRows frm = new frmTransferRows();
            Form.Show(frm);
        }
        /// <summary>
        /// ��ת���Ĳ��̵����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pandian_Press(object sender, EventArgs e)
        {
            frmConInventory frm = new frmConInventory();
            Form.Show(frm);
        }
        /// <summary>
        /// ��ʾ������Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plPerson_Press(object sender, EventArgs e)
        {
            frmMessage frm = new frmMessage();
            Form.Show(frm);
        }
        /// <summary>
        /// ע���˺ţ����ص���¼����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plZhuXiao_Press(object sender, EventArgs e)
        {
            MessageBox.Show("�Ƿ�ע����ǰ�û���", "ϵͳ����", MessageBoxButtons.OKCancel, (object sender1, MessageBoxHandlerArgs args) =>
             {
                 try
                 {
                     if (args.Result == ShowResult.OK)
                         Client.ReStart();
                 }
                 catch (Exception ex)
                 {
                     Toast(ex.Message);
                 }
             });
        }
    }
}