﻿using System.Collections.Generic;
using Portal.Web.ViewModels;
using Portal.Web.ViewModels.Account;
using Portal.Web.ViewModels.MemberChildBenefit;
using Portal.Web.ViewModels.MemberDues;
using Portal.Web.ViewModels.MemberInvmt;
using Portal.Web.ViewModels.Registration;

namespace Portal.Web.Interfaces
{
    public interface IAccount
    {
        CreateAccountResponse CreateAccount(CreateAccountRequest application);

        /// <summary>
        /// Gets the user's personal information
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns>The user's personal information</returns>
        Profile GetMemberProfile(int memberId);

        int UpdateProfile(Profile profile);

        int UpdateProfilePicUrl(int accountId, string url);

        List<Profile> GetUserProfiles();

        BaseResponse DeleteMember(int id);

        BaseResponse SetMemberPassword(ChangeMemPasswd request);

        #region Dues

        BaseResponse AddMemberDues(AddMemberDuesRequest request);

        List<MemberDuesViewModel> ViewAllMemberDues(int accountId);

        MemberDuesViewModel GetMemberDues(int duesid);

        BaseResponse UpdateMemberDues(EditMemberDuesRequest model);

        #endregion

        #region Investment

        BaseResponse AddMemberInvmt(AddMemberInvmtRequest request);

        List<MemberInvmtViewModel> ViewAllMemberInvestments(int memberId);

        MemberInvmtViewModel GetMemberInvmt(int invmtid);

        BaseResponse UpdateMemberInvmt(EditMemberInvmtRequest model);

        BaseResponse RequestInvestmentWithdrawal(WithdrawInvestmentRequest request);

        WithdrawInvestmentRequest GetInvestmentWithdrawRequest(int id);
                
        List<WithdrawInvestmentRequest> GetGrantedMemberInvestmentReqs(int memberId);

        List<WithdrawInvestmentRequest> GetAllInvestmentRequests();

        BaseResponse UpdateInvestmentRequest(WithdrawInvestmentRequest model);

        #endregion

        BaseResponse RequestLoan(LoanRequest request);

        List<LoanRequest> GetAllRequestedLoans();

        BaseResponse BenefitRequest(BenefitRequest request);

        List<BenefitRequest> GetAllRequestedBenefits();

        BenefitRequest GetBenefit(int id);

        BaseResponse UpdateBenefit(BenefitRequest request);
        
        LoanRequest GetLoan(int loanid);
        
        BaseResponse UpdateLoan(LoanRequest request);

        List<SupportViewModel> ViewAllMemberChildSupport(int id);

        BaseResponse AddMemberSupport(AddMemberInvmtRequest request);

        SupportViewModel GetMemberSupport(int id);

        BaseResponse UpdateMemberSupport(EditMemberInvmtRequest model);
    }
}