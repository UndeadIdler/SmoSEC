using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;
using SMOSEC.DTOs.Enum;
using SMOSEC.DTOs.InputDTO;
using SMOSEC.Domain.Entity;
using System.Data;
using SMOSEC.DTOs.OutputDTO;

namespace SMOSEC.UI.ConsumablesManager
{
    partial class frmTransferDetail : Smobiler.Core.Controls.MobileForm
    {
        #region "definition"
        AutofacConfig autofacConfig = new AutofacConfig();     //����������
        public String TOID;     //���������
        #endregion
        /// <summary>
        /// ����ȷ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Press(object sender, EventArgs e)
        {
            frmTransferDeal frm = new frmTransferDeal();
            frm.TOID = TOID;
            frm.Type = PROCESSMODE.����ȷ��;
            Show(frm, (MobileForm sender1, object args) =>
            {
                if (frm.ShowResult == ShowResult.Yes)
                    Bind();   //ˢ��������ʾ
            });
        }
        /// <summary>
        /// ����ȡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Press(object sender, EventArgs e)
        {
            frmTransferDeal frm = new frmTransferDeal();
            frm.TOID = TOID;
            frm.Type = PROCESSMODE.����ȡ��;
            Show(frm, (MobileForm sender1, object args) =>
            {
                if (frm.ShowResult == ShowResult.Yes)
                    Bind();   //ˢ��������ʾ
            });
        }
        /// <summary>
        /// ҳ���ʼ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTransferDetail_Load(object sender, EventArgs e)
        {
            Bind();
        }
        /// <summary>
        /// ���ݼ���
        /// </summary>
        public void Bind()
        {
            try
            {
                TOInputDto TOData = autofacConfig.assTransferOrderService.GetByID(TOID);
                coreUser DeanInUser = autofacConfig.coreUserService.GetUserByID(TOData.MANAGER);
                coreUser DealUser = autofacConfig.coreUserService.GetUserByID(TOData.HANDLEMAN);
                AssLocation assLocation = autofacConfig.assLocationService.GetByID(TOData.DESLOCATIONID);
                lblTDInMan.Text = DeanInUser.USER_NAME;
                lblDealMan.Text = DealUser.USER_NAME;
                lblLocation.Text = assLocation.NAME;
                DatePicker.Value = TOData.TRANSFERDATE;
                if (String.IsNullOrEmpty(TOData.NOTE)==false) lblNote.Text = TOData.NOTE;

                DataTable tableAssets = new DataTable();      //δ����SN���ʲ��б�
                tableAssets.Columns.Add("CID");               //�Ĳı��
                tableAssets.Columns.Add("NAME");              //�ʲ�����
                tableAssets.Columns.Add("IMAGE");             //�ʲ�ͼƬ
                tableAssets.Columns.Add("WAITREPAIRQTY");     //��ȷ������
                tableAssets.Columns.Add("STATUS");            //����״̬
                foreach (AssTransferOrderRow Row in TOData.Rows)
                {
                    ConsumablesOutputDto cons = autofacConfig.ConsumablesService.GetConsumablesByID(Row.CID);
                    if (Row.STATUS == 0)
                    {
                        tableAssets.Rows.Add(Row.CID, cons.NAME , cons.IMAGE , Row.INTRANSFERQTY, "������");
                    }
                    else if(Row.STATUS == 1)
                    {
                        tableAssets.Rows.Add(Row.CID, cons.NAME, cons.IMAGE, Row.INTRANSFERQTY, "�����");
                    }
                    else
                    {
                        tableAssets.Rows.Add(Row.CID, cons.NAME, cons.IMAGE, Row.INTRANSFERQTY, "��ȡ��");
                    }
                }
                if (tableAssets.Rows.Count > 0)
                {
                    ListAssets.DataSource = tableAssets;
                    ListAssets.DataBind();
                }
                if (Client.Session["Role"].ToString() == "SMOSECUser") plButton.Visible = false;
                //���ά�޵�����ɣ�������ά�޵�������ť
                if (TOData.STATUS == 1 || TOData.STATUS==2) plButton.Visible = false;
            }
            catch (Exception ex)
            {
                Toast(ex.Message);
            }
        }
    }
}