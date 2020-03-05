//
//  ResultOperationComponent.swift
//  hackaton-iOS
//
//  Created by Zendji Mizoguchi on 05/03/20.
//  Copyright © 2020 Zendji Mizoguchi. All rights reserved.
//

import UIKit
import BeagleUI

struct ResultOperationComponent: Widget {
    
    var appearance: Appearance?
    var flex: Flex?
    var accessibility: Accessibility?
    var id: String?
    
    func toView(context: BeagleContext, dependencies: RenderableDependencies) -> UIView {
        
        return UIView()
    }
    
}

struct ResultOperationEntity: ComponentEntity, ComponentConvertible {
    func mapToComponent() throws -> ServerDrivenComponent {
        return ResultOperationComponent()
    }
    
    
}
