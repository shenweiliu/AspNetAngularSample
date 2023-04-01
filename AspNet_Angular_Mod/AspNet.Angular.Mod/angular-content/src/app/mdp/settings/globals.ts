export const mdpCache: any = {    
    pageDirty: false,
    showLoader: false
}

export const MdpConfig: any = {
    webApiRootUrl: '/{companyId}/mdp/api/',  //with end slash. May use parentModel instead.
    companyRouteMain: ':companyId/mdp/mdphome/main',
    companyPathMain: '{companyId}/mdp/mdphome/main'    
}

export const SetConfigWithCompanyInfo = (companyId: string) => {
    MdpConfig.webApiRootUrl = MdpConfig.webApiRootUrl.replace('{companyId}', companyId);
    MdpConfig.companyPathMain = MdpConfig.companyPathMain.replace('{companyId}', companyId);
}







