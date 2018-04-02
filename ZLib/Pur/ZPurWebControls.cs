
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Drawing;
using System.IO;
namespace Z
{
    /// <summary>
    /// 控件接口，带权限控件所需实现的接口。
    /// </summary>
    public interface IPurControl
    {
        //事件
        event EventHandler Validate;

        //属性
        bool ActionCancel { get; set; }
        bool EnablePur { get; set; }
        string ModuleCode { get; set; }
        PurOperate Operate { get; set; }
        string AttributeToControl { get; set; }
    }

    /// <summary>
    /// 带权限的Button控件
    /// </summary>
    [DefaultProperty("Text"), ToolboxData("<{0}:ZButton runat=server></{0}:ZButton>")]
    public class ZButton : System.Web.UI.WebControls.Button, IPurControl
    {
        //成员
        private string _ModuleCode = string.Empty;
        private PurOperate _Operate = PurOperate.查询;
        private string _AttributeToControl = string.Empty;
        private bool _EnablePur = true;
        private bool _ActionCancel = false;
        private static readonly object EventValidate;

        // 事件
        [Browsable(false)]
        public event EventHandler Validate
        {
            add
            {
                base.Events.AddHandler(EventValidate, value);
            }
            remove
            {
                base.Events.RemoveHandler(EventValidate, value);
            }
        }

        static ZButton()
        {
            EventValidate = new object();
        }

        /// <summary>
        /// 调用事件注册的方法
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnValidate(EventArgs e)
        {
            EventHandler handler = (EventHandler)base.Events[EventValidate];
            if (handler != null)
            {
                handler(this, e);
            }
        }
        /// <summary>
        /// 重载事件回发
        /// </summary>
        /// <param name="eventArgument"></param>
        protected override void RaisePostBackEvent(string eventArgument)
        {
            //将权限验证事件OnValidate提前到OnClick之前
            this.OnValidate(EventArgs.Empty);

            //动作未被取消则继续引发其他事件 如click
            if (this._ActionCancel == false)
            {
                base.RaisePostBackEvent(eventArgument);
            }
        }

        #region IRbacControl 成员

        [Category("权限"), Description("是否启用权限控制"), DefaultValue(true)]
        public bool EnablePur
        {
            get { return this._EnablePur; }
            set { this._EnablePur = value; }
        }

        [DefaultValue(""), Category("权限"), Description("权限模块代码")]
        public string ModuleCode
        {
            get { return this._ModuleCode; }
            set { this._ModuleCode = value; }
        }

        [DefaultValue(""), Category("权限"), Description("权限操作类型")]
        public PurOperate Operate
        {
            get { return this._Operate; }
            set { this._Operate = value; }
        }
        [DefaultValue("Enabled"), Category("权限"), Description("权限控制的属性")]
        public string AttributeToControl
        {
            get { return this._AttributeToControl; }
            set { this._AttributeToControl = value; }
        }

        [Browsable(false), DefaultValue(false), Category("权限"), Description("是否取消控件动作")]
        public bool ActionCancel
        {
            get
            {
                return this._ActionCancel;
            }
            set
            {
                this._ActionCancel = value;
            }
        }

        #endregion
    }

    /// <summary>
    /// 带权限的ZImageButton控件
    /// </summary>
    [ToolboxData("<{0}:ZImageButton runat=server></{0}:ZImageButton>")]
    public class ZImageButton : System.Web.UI.WebControls.ImageButton, IPurControl
    {
        // 成员
        private string _ModuleCode = string.Empty;
        private PurOperate _Operate = PurOperate.查询;
        private string _AttributeToControl = string.Empty;
        private bool _EnablePur = true;
        private bool _ActionCancel = false;
        private static readonly object EventValidate;

        // 事件
        [Browsable(false)]
        public event EventHandler Validate
        {
            add
            {
                base.Events.AddHandler(EventValidate, value);
            }
            remove
            {
                base.Events.RemoveHandler(EventValidate, value);
            }
        }

        static ZImageButton()
        {
            EventValidate = new object();
        }

        /// <summary>
        /// 调用事件注册的方法
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnValidate(EventArgs e)
        {
            EventHandler handler = (EventHandler)base.Events[EventValidate];
            if (handler != null)
            {
                handler(this, e);
            }
        }
        /// <summary>
        /// 重载事件回发
        /// </summary>
        /// <param name="eventArgument"></param>
        protected override void RaisePostBackEvent(string eventArgument)
        {
            //将权限验证事件OnValidate提前到OnClick之前
            this.OnValidate(EventArgs.Empty);

            //动作未被取消则继续引发其他事件 如click
            if (this._ActionCancel == false)
            {
                base.RaisePostBackEvent(eventArgument);
            }
        }

        #region IRbacControl 成员

        [Category("权限"), Description("是否启用权限控制"), DefaultValue(true)]
        public bool EnablePur
        {
            get { return this._EnablePur; }
            set { this._EnablePur = value; }
        }

        [DefaultValue(""), Category("权限"), Description("权限模块代码")]
        public string ModuleCode
        {
            get { return this._ModuleCode; }
            set { this._ModuleCode = value; }
        }

        [DefaultValue(""), Category("权限"), Description("权限操作类型")]
        public PurOperate Operate
        {
            get { return this._Operate; }
            set { this._Operate = value; }
        }
        [DefaultValue("Enabled"), Category("权限"), Description("权限控制的属性")]
        public string AttributeToControl
        {
            get { return this._AttributeToControl; }
            set { this._AttributeToControl = value; }
        }

        [Browsable(false), DefaultValue(false), Category("权限"), Description("是否取消控件动作")]
        public bool ActionCancel
        {
            get
            {
                return this._ActionCancel;
            }
            set
            {
                this._ActionCancel = value;
            }
        }

        #endregion
    }

    /// <summary>
    /// 带权限的HzLinkButton控件
    /// </summary>
    [DefaultProperty("Text"), ToolboxData("<{0}:ZLinkButton runat=server></{0}:ZLinkButton>")]
    public class ZLinkButton : System.Web.UI.WebControls.LinkButton, IPurControl
    {
        // 成员
        private string _ModuleCode = string.Empty;
        private PurOperate _Operate = PurOperate.查询;
        private string _AttributeToControl = string.Empty;
        private bool _EnablePur = true;
        private bool _ActionCancel = false;
        private static readonly object EventValidate;
        private bool _EnablePostBack = true;

        // 事件
        [Browsable(false)]
        public event EventHandler Validate
        {
            add
            {
                base.Events.AddHandler(EventValidate, value);
            }
            remove
            {
                base.Events.RemoveHandler(EventValidate, value);
            }
        }

        static ZLinkButton()
        {
            EventValidate = new object();
        }

        /// <summary>
        /// 调用事件注册的方法
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnValidate(EventArgs e)
        {
            EventHandler handler = (EventHandler)base.Events[EventValidate];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 重载LinkButton PreRender
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            //为支持Firefox 以及 google浏览器
            //如果LinkButton被禁用，将脚本动作取消、将样式设为灰色
            if (!this.Enabled)
            {
                this.OnClientClick = "return false;";
                this.CssClass = "gray";
            }
        }

        /// <summary>
        /// 重载事件回发
        /// </summary>
        /// <param name="eventArgument"></param>
        protected override void RaisePostBackEvent(string eventArgument)
        {
            //将权限验证事件OnValidate提前到OnClick之前
            this.OnValidate(EventArgs.Empty);

            //动作未被取消则继续引发其他事件 如click
            if (this._ActionCancel == false)
            {
                base.RaisePostBackEvent(eventArgument);
            }
        }

        #region IRbacControl 成员

        [Category("权限"), Description("是否启用权限控制"), DefaultValue(true)]
        public bool EnablePur
        {
            get { return this._EnablePur; }
            set { this._EnablePur = value; }
        }

        [DefaultValue(""), Category("权限"), Description("权限模块代码")]
        public string ModuleCode
        {
            get { return this._ModuleCode; }
            set { this._ModuleCode = value; }
        }

        [DefaultValue(""), Category("权限"), Description("权限操作类型")]
        public PurOperate Operate
        {
            get { return this._Operate; }
            set { this._Operate = value; }
        }
        [DefaultValue("Enabled"), Category("权限"), Description("权限控制的属性")]
        public string AttributeToControl
        {
            get { return this._AttributeToControl; }
            set { this._AttributeToControl = value; }
        }

        [Browsable(false), DefaultValue(false), Category("权限"), Description("是否取消控件动作")]
        public bool ActionCancel
        {
            get
            {
                return this._ActionCancel;
            }
            set
            {
                this._ActionCancel = value;
            }
        }
        [Category("权限"), Description("是否显示回发"), DefaultValue(true)]
        public bool EnablePostBack
        {
            get { return this._EnablePostBack; }
            set { this._EnablePostBack = value; }
        }
        #endregion
    }
}